const mongoose= require('mongoose');

const userSchema = mongoose.Schema({
    userName:{
        type:String, required: true ,
    },
    email:{
        type:String, required: true
    },
    Password:{
        type:String, required: true
    },
    salary: {
        type:Number, required: true
    }
})


const BasicUser = mongoose.model('Basic' ,userSchema)

module.exports = BasicUser