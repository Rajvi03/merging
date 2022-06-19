const jwt = require('jwt');
const config = require('./config');

function verifytoken(req,res,next) {
    const token = req.headers['authorization'];

    jwt.verify(token,
        config.secretKey,{
            algorithm: config.algorithm
        },
        function(err,decoded){
            if(err){
                let err = {
                    message:err.message,
                    expiredAt:err.expiredAt
                };
                console.log(err)
                return res.status(401).json({message:"Unauthorized access"});
            }
            res.decoded = decoded;
            next()
        })
}

module.exports = verifytoken