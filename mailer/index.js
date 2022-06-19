var nodemailer = require('nodemailer');
const fs = require('fs')
const { promisify } = require("util");
const readFile = promisify(fs.readFile);

var transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'rajvisiddhpura7@gmail.com',
    pass: 'kkpptkwknzzjrror'
  }
});

// var mailOptions = {
//   from: 'rajvisiddhpura7@gmail.com',
//   to: 'dhruvsiddhpura123@gmail.com',
//   CC:'jhrayththa@gmail.com',
//   subject: 'Sending Email using Node.js',
//   text: 'That was easy!'
// };

// transporter.sendMail(mailOptions, function(error, info){
//   if (error) {
//     console.log(error);
//   } else {
//     console.log('Email sent: ' + info.response);
//   }
// });

fs.readFile('demo.html', {encoding: 'utf-8'}, function (err, html) {
    if (err) {
      console.log(err);
    } else {
      let mailOptions = {
        from: 'rajvisiddhpura7@gmail.com',
          to: 'dhruvsiddhpura123@gmail.com',
        subject: 'Sending Html in node mailer',
        html: html
      };
   
      transporter.sendMail(mailOptions, function(error, info) {
       if (error) {
        console.log(error);
       } else {
        console.log('Email has been sent: ' + info.response);
       }
     });
    }
   });