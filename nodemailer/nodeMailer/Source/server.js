const hbs = require('nodemailer-express-handlebars')
const nodemailer = require('nodemailer')
const path = require('path')

var transporter = nodemailer.createTransport({
    secure:true,
    service: 'gmail',
    requireTLS: true,
    port:465,
    secured:true,
    auth: {
        user: 'jhrayththa@gmail.com',
        pass: 'dhpqvxejxgedgkgn'
    },
});

const handlebarsOptions = {
    viewEngine: {
        partialsDir: path.resolve('./views/'),
        defaultLayout: 'false',
    },
    viewPath: path.resolve('./views/'),
}

transporter.use('compile', hbs(handlebarsOptions));

var mailOptions = {
    from: 'Jeet Raythatha <jhrayththa@gmail.com>',
    to: 'patelabhishek91787@gmail.com',
    subject: 'Sending Email using Node.js',
    text: 'That was easy!',
    template: 'email',
    context: {
        name: 'Ankit Rudani',
        company: 'WMV solurions!!'
    }
};

transporter.sendMail(mailOptions, function (error, info) {
    if (error) {
        console.log(error);
    } else {
        console.log('Email sent: ' + info.response);
    }
});