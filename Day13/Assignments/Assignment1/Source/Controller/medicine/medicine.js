const express =require('express');
const router = express.Router({'mergeParams':true});
const medicineDomain = require('../../Domain/mdedicine');
const MedicineDomain = new medicineDomain();

router.post('/addMedicine',MedicineDomain.addMedicine)

module.exports = router 