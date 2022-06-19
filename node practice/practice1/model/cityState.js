const mongoose = require('mongoose')

const cityStateSchema = new mongoose.Schema({
    _id: { type: Number,  unique: true },
    stateName: { type: String},
    cities: [
        {
            _id: { type: Number, unique: true },
            cityName: { type: String }
        }
    ]

})

const cityStateModel = mongoose.model('cityState', cityStateSchema)
module.exports = cityStateModel;