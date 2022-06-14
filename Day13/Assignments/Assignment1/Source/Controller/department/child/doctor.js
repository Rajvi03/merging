const express =require('express');
const router = express.Router({'mergeParams': true});
const departmentDomain = require('../../../Domain/department');
const DepartmentDomain = new departmentDomain();

router.post('/:id/addDoctor',DepartmentDomain.addDoctor)
router.get('/:id/Doctor/:docId',DepartmentDomain.getDoctor)
router.put('/:id/editDoctor/:docId',DepartmentDomain.editDoctor)
router.delete('/:id/deleteDoctor/:docId',DepartmentDomain.deleteDoctor)

module.exports = router     