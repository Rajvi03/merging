const mongoose = require('mongoose');

const hrSchema = mongoose.Schema({
    userName: {
        type: String, required: true,
    },
    email: {
        type: String, required: true
    },
    Password: {
        type: String, required: true
    }
})


const HrUser = mongoose.model('Basic',hrSchema)

module.exports = HrUser;