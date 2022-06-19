var express = require('express');
const mongoose = require('mongoose');
var multer = require('multer');
var path = require('path');
var Excel = require('./model.js');
var excelToJson = require('convert-excel-to-json');
var bodyParser = require('body-parser');
var storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, './uploads')
    }
    , filename: function (req, file, cb) {
        cb(null, file.originalname)
    }
}
);
var upload = multer({ storage: storage });

mongoose.connect('mongodb://127.0.0.1:27017//ExterNalExamDb', { useNewUrlParser: true })
    .then(() => {
        console.log('Connected to MongoDB');    
    }).catch(err => {
        console.log('Error connecting to MongoDB: ' + err.message);
    });

var app = express();
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.resolve(__dirname, 'public')));

app.get('/' , function(req, res){   
    res.sendFile(path.resolve(__dirname, 'index.html'));
});

app.post('/uploadfile',upload.single("uploadfile") ,(req, res) => {
importExceldata2MongoDB(__dirname + '/uploads/' + req.file.originalname);
console.log(res);
});

function importExceldata2MongoDB(filePath) {
    const excelData = excelToJson({
        sourceFile: filePath,
        header: {
            rows: 1
        },
        columnToKey: {
            A: 'first_name',
            B: 'last_name',
            C: 'email',
            D: 'password',
            E: 'created_date'
        }
    });
    console.log(excelData);
}

Excel.inserMany(jsonObj ,(err, data) =>{
    if(err){
        console.log(err);
    }
    else{
        console.log(data);
        res.redirect('/');
    }

});

app.listen(3000,()=>{
    console.log('Server is running on port 3000');
})