const UserModel = require('../Model/user.model');

class UserDomain {

    async getAllUsers(req, res) {
        try {
            const users = await UserModel.find();
            if (users) {
                res.status(200).send(users);
            } else return res.status(404).json({ message: 'Users not found' });
        } catch (err) {
            res.send(err);
        }
    }
    async getUserById(req, res) {
        let id = req.params.id;
        try {
            const user = await UserModel.findById(id);
            if (user) {
                res.status(200).send(user);
            } else {
                return res.status(404).json({ message: 'User not found' });
            }
        } catch (err) {
            console.log(err);
        }
    }
    async createUser(req, res) {
        let data = req.body;
        try {
            const user = new UserModel(data);
           await user.save();
            res.status(200).send(user);
        } catch (err) {
            console.log(err);
        }
    }
    async updateUser(req, res) {
        let id = req.params.id;
        let data = req.body;
        try {
            const user = await UserModel.findByIdAndUpdate(id, data, { new: true });
            if (user) {
                res.status(200).send(user);
            }
            else {
                return res.status(404).json({ message: 'User not found' });
            }
        } catch (err) {
            console.log(err);
        }
    }
    async deleteUser(req, res) {
        let id = req.params.id;
        try {
            const user = await UserModel.findByIdAndDelete(id);
            if (user) {
                res.status(200).send(user);
            }
            else {
                return res.status(404).json({ message: 'User not found' });
            }
        } catch (err) {
            console.log(err);
        }
    }
}

module.exports = UserDomain;