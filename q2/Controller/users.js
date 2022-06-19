const BasicUser = require('../Model/user');
var express = require('express');
var router= express.Router();

router.get('/users/:userId' ,async (req,res)=>{
    try{
        var user = await BasicUser.findById(req.params.userId);
        res.send(user);
    }catch(err){
        res.status(404).send('Not Found')
    }
});

module.exports =router