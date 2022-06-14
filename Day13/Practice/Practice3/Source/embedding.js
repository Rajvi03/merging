const mongoose = require('mongoose')
// console.log('hello');

mongoose.connect('mongodb://localhost:27017/module13Practice1')
.then(()=> console.log('Connexted to MongoDb...'))
.catch(err=>console.error('Could not connect to MongoDb...',err))

const authorSchema = new mongoose.Schema({
    name:String,
    bio:String,
    website:String
})

const Author = mongoose.model('Author',authorSchema);

const Course = mongoose.model( 'Course',new mongoose.Schema({
    name:String,
    authors:[authorSchema],
    
}));

async function createCourse(name,authors){
    const course = new Course({
        name,
        authors
    })
    const result = await course.save()
    console.log(result);
}
// createCourse('React Course', [
//     new Author({name:'Mosh'}),
//     new Author({name:'John'})
// ])

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

async function addAuthor(courseId,author){
    const course = await Course.findById(courseId);
    course.authors.push(author);
    console.log('Author added Successfully');
    course.save()
}

// addAuthor('62a2ffe1263e0fe3b45c4ae9', new Author ({name:'Any'}))

async function removeAuthor(courseId,authorId){
    const course = await Course.findById(courseId);
    const author = course.authors.id(authorId)
    author.remove();
    console.log('Author deleted Successfully');
    course.save();
}
removeAuthor('62a2ffe1263e0fe3b45c4ae9','62a3016ba0462b0806ac3a87')