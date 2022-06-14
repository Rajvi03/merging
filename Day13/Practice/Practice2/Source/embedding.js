const mongoose = require('mongoose')
// console.log('hello');

mongoose.connect('mongodb://localhost:27017/module13Practice1')
.then(()=> console.log('Connexted to MongoDb...'))
.catch(err=>console.error('Could not connect to MongoDb...',err))

const authorSchema = new mongoose.Schema({
    name:String,
    bio:{type:String,required:true},
    website:String
})

const Author = mongoose.model('Author',authorSchema);

const Course = mongoose.model( 'Course',new mongoose.Schema({
    name:String,
    author: {
        type:authorSchema,
        required:true
    }
}));

async function createCourse(name,author){
    const course = new Course({
        name,
        author
    })
    const result = await course.save()
    console.log(result);
}
createCourse('Node Course', new Author({name:'John'}))

async function listCourses(){
    const courses = await Course.find();
    console.log(courses);
}
// listCourses()

async function updateAuthor(courseId){
    await Course.updateOne({_id:courseId},{
        $set:{'author.name':'John Smith'}
    })
}

// updateAuthor('62a2ecf875e5026bcda9fe01')

async function deleteAuthor(courseId){
    await Course.updateOne({_id:courseId},{
        $unset:{'author':''}
    })
}
// deleteAuthor('62a2ecf875e5026bcda9fe01')