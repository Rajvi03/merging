const express = require('express');
const stateCityDomain = require('../domain/stateCity');
const router = express.Router({'mergeParams':true});

const StateCityeDomain = new stateCityDomain();

router.post('/addStateCity',StateCityeDomain.addStateCity)
router.post('/:id/addCities',StateCityeDomain.addCitites)

module.exports = router;