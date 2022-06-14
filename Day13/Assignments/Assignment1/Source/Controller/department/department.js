const express =require('express');
const router = express.Router({'mergeParams':true});
const departmentDomain = require('../../Domain/department');
const DepartmentDomain = new departmentDomain();

const doctor = require('./child/doctor')
const assistant = require('./child/assistant')

router.use('/',doctor)
router.use('/',assistant)


router.get('/',DepartmentDomain.getDepartments)
router.post('/addDepartment',DepartmentDomain.addDepartment)

module.exports = router 