const jwt = require('jsonwebtoken')
const config = require('./config')

const verifyUser = (req,res,next)=>{
    if(req.headers['token']){
        jwt.verify(req.headers['token'],config.key,{algorithm:config.algorithm,expiresIn:config.expiresIn}),(err,decoded)=>{
            if(err){
                return res.status(401).send('user not verify so access is not given')
            }
            if(decoded){
                req.headers['data']=decoded;
                console.log('decoded successfully')
                next();
            }
        }
    }
    else{
        res.status(404).send('token not provided')
    }
}
module.exports = verifyUser