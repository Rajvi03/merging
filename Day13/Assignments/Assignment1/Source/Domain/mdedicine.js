const { medicineModel } = require('../Model/medicine');

class medicineDomain {
    async addMedicine(req, res) {
        var MedicineModel = new medicineModel(req.body)
        var result = await MedicineModel.save()
        res.send(result);
        res.end();
    }
}
module.exports = medicineDomain 