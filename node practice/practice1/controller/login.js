const config = require('../authentication/config')
const jwt = require('jsonwebtoken')
const express = require('express');
const router = express.Router();

router.post('/',(req,res)=>{
    let userData = {
        userName:req.body.userName,
        password:req.body.password,
        role:['admin','user']
    }
    
    if(userData.userName=='admin' && userData.password=='admin'){
        let token = jwt.sign(userData,config.key,{algorithm:config.algorithm,expiresIn:config.expiresIn})
         res.status(200).send({msg:'login Successfully',Token:token})
    }
    else{
        res.status(401).send('please enter valid data')
    }
})

module.exports= router