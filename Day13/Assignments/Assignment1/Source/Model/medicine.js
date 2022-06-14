const mongoose = require('mongoose')
  
const medicineSchema = new mongoose.Schema({
    _id:Number,
    medicineName: String
})

const medicineModel = mongoose.model('medicine',medicineSchema)
module.exports = {medicineModel};