var UserDomain = require('../Domain/user.domain');
var express = require('express');
var router = express.Router();

class UserController{
    static async getAllUsers(){
        const user = new UserDomain();
        user.getAllUsers();
    }
    static async getUserById(){
        const user = new UserDomain();
        user.getUserById();
    }
    static async createUser(){
        const user = new UserDomain();
        user.createUser();
    }
    static async updateUser(){
        const user = new UserDomain();
        user.updateUser();
    }
    static async deleteUser(){
        const user = new UserDomain();
        user.deleteUser();
    }
}

router.get('/' , UserController.getAllUsers);
router.get('/:id' , UserController.getUserById);    
router.post('/' , UserController.createUser);
router.put('/:id' , UserController.updateUser);
router.delete('/:id' , UserController.deleteUser);


module.exports = router