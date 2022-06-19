require('dotenv').config();
var express = require('express');
var app = express();
var users = require('./Controller/user.controller');
const mongoose = require('mongoose');

var port = process.env.PORT || 3000;

mongoose.connect('mongodb://127.0.0.1:27017/ExterNalExamDB')
    .then(() => {
        console.log('Connected to MongoDB');
    }
    ).catch((err) => console.log(err));

app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use('/users', users);

app.listen(port, () => {
    console.log(`Server is running on port ${port}`);
});