const express = require('express')
const app = express();
app.use(express.json())

const mongoose = require('mongoose');
const connect = mongoose.connect('mongodb://localhost:27017/practice1')
.then(()=>{console.log('Connected Successfully')})
.catch(()=>{console.log('somthing wrong',err)});

const logger = require('./middleware/logger')
const mw = [logger.logger,logger.errorHandler]

app.listen(3000,()=>{
    console.log('server is listining on port 3000')
})

const login = require('./controller/login')
app.use('/login',login)
const verify = require('./authentication/verify')

const stateCity = require('./controller/stateCity');
const student = require('./controller/student')
// app.use(mw[0]);
// app.use(verify)
app.use('/stateCity',stateCity)
app.use('/student',student)

app.use(mw[1]);