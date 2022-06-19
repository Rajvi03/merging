const express = require('express');

var router = express.Router();
var jwt =require('jwt');
var config = require('../authentication/config');

router.post("/", function (req, res){
    let userData={
        username: req.body.username,
        password: req.body.password,
        role: req.body.role
    }
    let token = jwt.sign(userData,config.secretKey,{
        algorithm: config.algorithm,
        expiresIn: config.expiresIn
    });
    if(userData.role==="basicuser"){
        res.status(200).json({
            message:"Welcome Basic User",
            jwttoken: token
        });
    }
   else if(userData.role==="Hr"){
        res.status(200).json({
            message:"Welcome Hr User",
            jwttoken: token
        });
    }else{
        res.status(401).json({
            message:"Login Failed",})
    }
});

module.exports = router;