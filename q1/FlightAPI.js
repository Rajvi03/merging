var express = require('express');
var app = express();
const BookingDetails = require('./Models/bookingdetails')

app.use(express.json());

app.post('/booking',(req,res) => {
    const bookingDetails = new BookingDetails(req.body)
    res.send(bookingDetails);
});

app.get('/booking/:bookingId' ,(req,res)=>{
    const BookeTicket = BookingDetails.findByBookingId(req.params.bookingId);
    if(!BookeTicket) return res.
})