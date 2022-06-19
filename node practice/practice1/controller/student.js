const express = require('express');
const studentDomain = require('../domain/student');
const router = express.Router({'mergeParams':true});

const StudentDomain = new studentDomain();
router.post('/addStudents',StudentDomain.addStudents)
router.get('/students',StudentDomain.getStudents)
router.get('/students/:id',StudentDomain.getAnStudent)
router.get('/students/city/:cId',StudentDomain.getStudentByCity)
router.get('/students/sameDate/d',StudentDomain.getstuByDate)
router.put('/students/updateSalary',StudentDomain.updateSalary)

module.exports = router;