const mongoose = require('mongoose')

const doctorSchema = new mongoose.Schema({
    _id:Number,
    name:String
})
const assistantSchema = new mongoose.Schema({
    _id:Number,
    name:String
})  
const departmentSchema = new mongoose.Schema({
    
    departmentName: String,
    doctors: [doctorSchema],
    assistants : [assistantSchema]
    
})
const doctorModel = mongoose.model('Doctor',doctorSchema);
const assistantModel = mongoose.model('Assistant',assistantSchema);
const departmentModel = mongoose.model('department',departmentSchema)
module.exports = {departmentModel,doctorModel,assistantModel};