const productModel = require("../models/product.model");
const {validationResult} = require("express-validator"); 
const { findOne } = require("../models/product.model");
exports.product = function(req,res){
    res.render("product/add"); // Hiển thị trang product/add trên client
}
exports.postProduct = async function(req,res){
    const data = req.body;
    console.log(data);
    const errors = validationResult(req);
    if(!errors.isEmpty()){
        return res.send(errors.array());
    }
    try {
        if(req.file) {
            const file = req.file;
            const fs = require("fs");
            const img = fs.readFileSync(file.path);
            data.image = {
                contentType: file.mimetype,
                data: img.toString("base64")
            }
        }
        //Kiểm tra xem sp đã có trong db chưa 
        
        const exist = await productModel.findOne({name:data.name});
        if(exist) {
            return res.send("Existed !!")
        }
        //res.send(data);
        const p = new productModel(data);
        await p.save();
        res.send("Add Product Successfully");  
    } catch (error) {
        res.send(error);
    }
};



exports.showProduct = async (req, res) => {
    try {
      // Sử dụng Model để lấy danh sách sản phẩm từ cơ sở dữ liệu MongoDB
      const products = await productModel.find({});
  
      // Render view và truyền danh sách sản phẩm vào nó
      res.render("product/show", { products: products }, (err, html) => {
        if (err) {
          console.log(err);
          res.status(500).send('Internal Server Error');
        } else {
          res.send(html);
        }
      });
    } catch (err) {
      console.log(err);
      res.status(500).send('Internal Server Error');
    }
  };
  
  
exports.deleteProduct = async function(req, res){
    const existProductId = req.params.id;
    try {
        const existProduct = await productModel.findById(existProductId);
        if(!existProduct){
            res.send('Product not found!');
        }
        const deleteProduct = await productModel.deleteOne({_id: existProductId});
        res.redirect("/product/show");
    }catch (e){
        res.send('Deleting product error: ' + e.message);
    }
}

  
  
  
  
  
  
  
