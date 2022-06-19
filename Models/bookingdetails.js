const mongoose = require('mongoose');

const BookingDetails= mongoose.model('Booking' ,new Schema({
    BookingID:{
        type:Number,
        required:true
    },
    FlightID:{
        type:Number,
        ref:"Flight",
    },
    PassengerID:{
        type:Number,
        ref:"Passenger",
    },
    BookingDate:{
        type:Date,
        ref:"BookingDetails"
    },
    TravelDate:{
        type:Date,
    },
    DepartureTime:{
        type:Date,
    },
    ArrivalTime:{
        type:Date,
    }
}))

module.exports =BookingDetails;