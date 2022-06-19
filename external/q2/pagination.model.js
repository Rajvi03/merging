const mongoose = require("mongoose");

var schema = new mongoose.Schema({
    _id:{
        type: Number,
        required: true,
    },
    name: { type: String, required: true },

})
var model = mongoose.model('pagination', schema);
module.exports = model;