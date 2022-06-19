const mongoose = require('mongoose')

const studentSchema = new mongoose.Schema({
    _id :{type:Number,required:true},
    Name:{type:String,required:true},
    phoneNo:{type:Number,required:true},
    email:{type:String,required:true},
    DOB:{type:Date,default:Date.now()},
    salary:{type:Number},
    department:{type:String,enum:['Hr','Sales']},
    address:{
        stateId:{type:Number,ref:'cityState'},
        cityId:{type:Number,ref:'cityState'},
    },
    fees:{
        Amount:{type:Number,required:true},
        PaymentDate:{type:Date,default:Date.now()},
        Status:{type:Boolean,required:true}
    },
    result:{
        hindi:{type:Number,required:true},
        english:{type:Number,required:true},
        maths:{type:Number,required:true},
        total:{type:Number,required:true}
    }
})

const studentModel = mongoose.model('student',studentSchema)
module.exports = studentModel;
