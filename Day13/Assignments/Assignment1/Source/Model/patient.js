const mongoose = require('mongoose')

const patientSchema = new mongoose.Schema({
    _id: Number,
    patientName: String,
    doctors:[{
        name:String,
    }],
    department:{
        deptName:String,
    },
    medicines: [    
        {
            medicine: {
                type: Number,
                ref: "medicine",
            },
            doses: [
                {
                    type: String,
                    enum: ["morning", "afternoon", "night"]
                }
            ],
        },
    ],
})

const patientModel = mongoose.model('patient', patientSchema)
module.exports = { patientModel };