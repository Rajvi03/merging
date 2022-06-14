const { departmentModel } = require('../Model/department');
const { medicineModel } = require('../Model/medicine');
const { patientModel } = require('../Model/patient');

class patientDomain {
    async addPatient(req, res) {
        var department = await departmentModel.findById(req.body.departmentId)
        // var medicine = await medicineModel.findById(req.body.medicineId)
        // console.log(medicine);
        // console.log(medicine.medicineName);
        var doc = req.body.doctorId
        var doctorId = await department.doctors.findIndex((e)=>{
            return e._id == doc
        })
        console.log(doctorId);
        var PatientModel = await new patientModel({
            _id: req.body._id,      
            patientName: req.body.patientName,
            doctors: {name:department.doctors[doctorId].name},
            department:department.departmentName,
            medicines: req.body.medicines,
            // medicines: {medicine:medicine.medicineName,doses:req.body.medicines.doses},
        })
        var result = await PatientModel.save()
        res.send(result);
        res.end();
    }
    async getMedicineList(req,res){
        var data = await patientModel.findById(req.params.id,{medicines:1})
        // var data = await patientModel.find().populate('name')
        console.log(data);
        res.send(data);
        res.end();    
    }
}
module.exports = patientDomain 