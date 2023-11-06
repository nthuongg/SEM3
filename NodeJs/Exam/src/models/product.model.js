const mongoose = require("mongoose");
const product_schema = new mongoose.Schema({
    code: {
        type :String,
        required:[true,"Trường này bắt buộc phải nhập dữ liệu"],
    },
    name:{
        type :String,
        required:[true,"Trường này bắt buộc phải nhập dữ liệu"],

    },
    date:{
        type: Date,
        required: true
    },
    price:{
        type: String,
    },
    quantity:{
        type: Number
    },
    storeCode:{
        type: String
    }
});
module.exports = mongoose.model("Product", product_schema); //product