const mongoose = require('mongoose');

const Passenger = mongoose.model("Passenger" , new Schema({
    PassengerID:{
        type:Number,
        Name:{
            type:String,
            require:true
        },
        DOB:{
            type:Date,
            require:true
        }
    }
}));

module.exports =Passenger;