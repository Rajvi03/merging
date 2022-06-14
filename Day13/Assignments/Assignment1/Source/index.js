const express = require('express')
const app = express();
const mongoose = require('mongoose')
const connect = mongoose.connect('mongodb://localhost:27017/assignment13DB')
app.use(express.json())

const Department = require('./Controller/department/department')
const Medicine = require('./Controller/medicine/medicine')
const Patient = require('./Controller/patient/patient')

app.use('/department',Department)
app.use('/medicine',Medicine)
app.use('/patient',Patient)


app.listen(3000,()=>{  
    console.log("server is running on port 3000");
})

