const mongoose = require('mongoose');

const userSchema = new mongoose.Schema({
    _id: mongoose.Schema.Types.ObjectId,
    first_name:{
        type: String,
        required: true
    },
    last_name:{
        type: String,
        required: true
    },
    email:{
        type: String,
        required: true,
        unique: true
    },
    password:{
        type: String,
        required: true
    },
    created_date:{
        type: Date,
        default: Date.now,
        required: true
    }
    });

    var UserModel = mongoose.model("User", userSchema);

    module.exports = UserModel;