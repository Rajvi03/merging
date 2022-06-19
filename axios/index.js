const express =  require('express');
const app = express();
const fs = require('fs/promises')
const axios = require('axios')
// const agent = new https.Agent({ rejectUnauthorized: false });
// { httpsAgent: agent }
var jsondata;
app.get("/api",async (req,res)=>{
    try{
        const response = await axios({
            url:"https://res.cloudinary.com/des3si8bs/raw/upload/v1654770778/attendance/attandance_alc65n.JSON",
            method:"get"
        });
        jsondata = response.data;
        await fs.writeFile('text.json', response.data, (err) => {
            if (err)
                throw err;
            console.log('Data added');
        })
        res.status(200).send(response.data);
        // console.log(response.data);

       
    }
    catch(err){
        res.status(500).send({message:err});
    }
})



app.listen(3000,()=>console.log('app is listning at port 3000'));