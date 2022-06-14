const express =require('express');
const router = express.Router({'mergeParams':true});
const patientDomain = require('../../Domain/patient');
const PatientDomain = new patientDomain();

router.get('/:id/medicineList',PatientDomain.getMedicineList)
router.post('/addPatient',PatientDomain.addPatient)

module.exports = router 