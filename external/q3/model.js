const mongoose = require('mongoose');

var excelSchema = new mongoose.Schema({
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
        required: true
    },
    password:{
        type: String,
        required: true
    },
    created_date:{
        type: Date,
        default: Date.now

    }
});
module.exports = mongoose.model('Excel', excelSchema);