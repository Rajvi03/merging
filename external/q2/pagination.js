const mongoose = require('mongoose');
var express = require("express");
var app = express();
var model = require("./pagination.model");

mongoose.connect('mongodb://127.0.0.1:27017/ExterNalExamDB', { useNewUrlParser: true })
    .then(() => console.log('Connected to MongoDB...'))
    .catch(err => console.error('Could not connect to MongoDB...', err));

app.use(express.json());

app.post('/users', (req, res) => {
    var user = new model(req.body);
    user.save()
        .then(() => res.json('User added!'))
        .catch(err => res.status(400).json('Error: ' + err));
});

app.get('/users', (req, res) => {
    model.find()
        .then(users => res.json(users))
        .catch(err => res.status(400).json('Error: ' + err));
})



app.get('/users/paginate', async (req, res) => {
    const pageNumber=1;
    const pageSize=10;
    const users = await model.find()
    .skip((pageNumber-1)*pageSize)
    .limit(pageSize)
    .sort({name:1}) // sort by name in ascending order});
    .exec();
    res.json(users);
});
app.listen(3000, () => {
    console.log("Server is running on port 3000");
})