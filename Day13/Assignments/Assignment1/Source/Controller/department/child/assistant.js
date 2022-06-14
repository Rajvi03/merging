const express =require('express');
const router = express.Router({'mergeParams': true});
const departmentDomain = require('../../../Domain/department');
const DepartmentDomain = new departmentDomain();

router.post('/:id/addAssistant',DepartmentDomain.addAssistant)

module.exports = router     