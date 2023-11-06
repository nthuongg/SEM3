require("dotenv").config(); 
const express = require("express");

// set up express app
const app = express(); // host - app

// set up port number
const port = 1234;

app.listen(port,function() {
    console.log("Server is running...");
})
// use views
app.set("view engine", "ejs");

// use file 
app.use(express.static("public"));
app.use(express.json());
app.use(express.urlencoded({extended:true}));

//connect database 
require("./src/db/connect");

//set session
const session = require("express-session");
app.use(
    session({
        resave: true,
        saveUninitialized: true,
        secret: process.env.SESSION_SECRET,  //
        cookie: {
            maxAge: +process.env.COOKIE_MAXAGE, //milisecond
            secure: false,
        }
    })
)

//routes
const product_route = require("./src/routes/product.route");
app.use("/product",product_route);
