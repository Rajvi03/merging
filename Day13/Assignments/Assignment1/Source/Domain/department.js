const { doctorModel, departmentModel, assistantModel } = require('../Model/department')

class departmentDomain {
    async getDepartments(req, res) {
        try {
            var DepartmentModel = await departmentModel.find();
            console.log(DepartmentModel);
            res.send(DepartmentModel);
            res.end();
        }
        catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
    async addDepartment(req, res) {
        try {
            var DepartmentModel = new departmentModel(req.body)
            var result = await DepartmentModel.save()
            res.send(result);
            res.end();
        } catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
    async getDoctor(req, res) {
        try {
            var DepartmentModel = await departmentModel.findById(req.params.id)
            if (DepartmentModel == null) {
                res.status(404).send(`department Id = ${req.params.id} is not found`)
            }
            else {
                var doc = DepartmentModel.doctors
                if (doc == false) {
                    res.status(404).send(`doctor not found`)
                }
                else {
                    var result = await doc.find((d) => {
                        return d._id == req.params.docId
                    })
                    if (result == null) {
                        res.status(404).send(`doctor Id = ${req.params.aid} is not found`)

                    }
                    else {
                        console.log(result);
                        res.send(result);
                        res.end();
                    }
                }
            }
        } catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
    async addDoctor(req, res) {
        try {
            var DepartmentModel = await departmentModel.findById(req.params.id)
            if (DepartmentModel == null) {
                res.status(404).send(`department Id = ${req.params.id} is not found`)
            }
            else {
                DepartmentModel.doctors.push(new doctorModel(req.body))
                var result = await DepartmentModel.save()
                res.send(result);
                res.end();
            }
        }
        catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
    async editDoctor(req, res) {
        try {
            var dept = await departmentModel.findById(req.params.id)
            if (dept == null) {
                res.status(404).send(`department Id = ${req.params.id} is not found`)
            } else {
                var doc = dept.doctors
                if (doc == false) {
                    res.status(404).send(`doctor not found`)
                }
                else {
                    var result = await doc.findIndex((d) => {
                        return d._id == req.params.docId
                    })
                    if (result == null) {
                        res.status(404).send(`doctor Id = ${req.params.aid} is not found`)
                    }
                    else {
                        doc[result].set(req.body)
                        dept.save();
                        console.log(dept);
                        res.send(dept)
                        res.end();
                    }
                }
            }
        }
        catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
    async deleteDoctor(req, res) {
        try {
            var dept = await departmentModel.findById(req.params.id)
            if (dept == null) {

            }
            else {
                var doc = dept.doctors
                if (doc == false) {
                    res.status(404).send(`Doctor not found`)
                }
                else {
                    var result = await doc.id(req.params.docId)
                    if (result == null) {
                        res.status(404).send(`doctor Id = ${req.params.aid} is not found`)
                    } else {
                        result.remove();
                        dept.save();
                        console.log("doctor is deleted successfully");
                        console.log(dept);
                        res.send(dept)
                        res.end();
                    }
                }
            }
        }
        catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }

    async addAssistant(req, res) {
        try {
            var DepartmentModel = await departmentModel.findById(req.params.id)
            if (DepartmentModel == null) {
                res.status(404).send(`department Id = ${req.params.id} is not found`)
            }
            else {
                DepartmentModel.assistants.push(new assistantModel(req.body))
                var result = await DepartmentModel.save()
                res.send(result);
                res.end();
            }
        }
        catch (error) {
            console.log(error.message);
            res.send(error.message);
        }
    }
}

module.exports = departmentDomain;