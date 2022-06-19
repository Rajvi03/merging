
const cityStateModel = require("../model/cityState");


class stateCityDomain {
    async addStateCity(req, res, next) {
        try {
            const stateCity = new cityStateModel(req.body)
            const result = await stateCity.save();
            res.status(200).send(result)
            console.log(result);
            res.end();
        }
        catch (err) {
            next(err)
        }
    }
    async addCitites(req, res, next) {
        try {
            const findStateId = await cityStateModel.findById(req.params.id)
            if (findStateId == undefined) {
                res.status(404).send('state id is not found')
            }
            else {
                findStateId.cities.push(req.body);
                findStateId.save();
                res.status(200).send(findStateId);
                console.log(findStateId);
                res.end();
            }
        } catch (error) {
            next(error)
        }
    }
}

module.exports = stateCityDomain;