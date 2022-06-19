const logger = (req,res,next)=>{
    console.log(`url : ${req.url}\nmethod : ${req.methods}\ntime : ${Date.now()}`)
    next();
}
const errorHandler = (err,req,res,next)=>{
    console.error(err.stack);
    res.status(404).send('Something wents wrong');
}

module.exports = {logger,errorHandler}