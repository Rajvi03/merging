const studentModel = require("../model/student")


class studentDomain{
    async addStudents(req,res,next){
        try{
            const students = new studentModel(req.body)
            const result = await students.save()
            console.log(result);
            res.send(result);
            res.end();
        }
        catch(err){
            next(err)
        }
    }
    async getStudents(req,res,next){
        try {
            const students = await studentModel.find().populate("address.stateId","address.cityId");
            console.log(students)
            res.send(students);
            res.end();
        } catch (error) {
            next(error)
        }
    }
    async getAnStudent(req,res,next){
        try {
            const stuID = await studentModel.findById(req.params.id)
            console.log(stuID);
            res.send(stuID);
            res.end();
        } catch (error) {
            next(error)
        }
    }
    async getStudentByCity(req,res,next){
        console.log('----------');
        let count=0;
        try {
            const student = await studentModel.find();
            console.log('------students----');
            // console.log(student[0].address.cityId);
            console.log('----------');
            const stu = student.filter((e)=>{
                if(e.address.cityId == req.params.cId){
                    return count++;
                }
            })
            console.log("total no. of students : " + count)
            console.log(count)
            res.status(200).send(`${count}`);
            res.end();
            
            
        } catch (error) {
            next(error)
        }
    }
    async getstuByDate(req,res,next){
        const student = await studentModel.find({DOB:"19/6/2022"});
        
        console.log(student)
        res.send(student);
        res.end();


    //    var sameDate;
    //     for(let e=0;e<student.length;e++){
    //         var D = e.DOB;
    //         console.log(D)
    //          sameDate =  await student.filter((a)=>{
    //             return a.DOB == D;
    //         })
    //         console.log(sameDate);
    //     }
    //     res.send(sameDate);
    //     res.end()
        // await student.forEach(async (e)=>{
        //     var D = e.date;
        //     var sameDate =  await student.filter((a)=>{
        //         return a.date == D;
        //     })
        //     console.log(sameDate);
        //     res.send(sameDate);
        //     res.end()
        // })
        
    }
    async updateSalary(req,res,next){
        
        const student = await studentModel.updateMany({department:{$in:["Hr"]}},{$mul:{salary:1.2}});
        console.log(student);
        res.send(student);
        res.end();
        // console.log(student[0].department)

        // for(let i =0; i <= student.length;i++){
        //     if(student[i].department=="Hr"){
        //         student[i].salary = student[i].salary + (student[i].salary * 0.20)
        //     } 
        //     console.log(student[i]);
        //     res.send(student[i]);
        //     res.end()
        // }
        // const stu = student.forEach(e => {
        //     if(e.department=="Hr"){
        //         return e.salary = e.salary + (e.salary * 0.20)
        //     }
        // });
        // console.log(stu);
        // res.send(stu);
        // res.end()
        // db.emp.update({ "name": { $in: ["Ravi", "John"] } }, { $mul: { salary: 1.1 } });

    }


}

module.exports= studentDomain;