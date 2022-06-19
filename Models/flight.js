const mongoose = require('mongoose');

var Flight = mongoose.model('Flight' , new Schema({

    FlightID:{
        type:Number,
        required:true,
    },
    Name:{
        type:String,
        required:true,
    },
    DepartureTime:{
        type:Date,
        enum:['08:00AM', '08:00PM' ,'04:00AM']
    },
    duraation:{
        type:Date.getTime(),
    },
    Days:{
        type:String,
        enum:['Mon','Tue','Wed','Thu','Fri','Sat'],
    }
}));

module.exports = Flight