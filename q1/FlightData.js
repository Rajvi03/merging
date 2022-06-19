const mongoose = require('mongoose');

var Customer = mongoose.model('Customer',new Schema({
    FlightID:{
        type:Number,
        require:true,
        ref:'Flight'
    },
    PassengerID:{
        type:Number,
        require:true,
        ref:'Passenger'
    },
    BookingDate:{
        type:Date,
        default:Date.now(),
        ref:'BookingDetails'
    },
    travelDate:{
        type:Date,
    },
    noofseats:{
        type:Number,
        required:true
    },
    DepartureTime:{
        type:Date.getTime(),
        required:true
    }
}))
module.exports= Customer