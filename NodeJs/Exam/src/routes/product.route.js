const express = require("express");
const router = express.Router();
const controller = require("../controllers/product.controller");


// Route để hiển thị danh sách sản phẩm
router.post("/delete/:id", controller.deleteProduct)
router.get("/show", controller.showProduct)
router.get("/add", controller.product)
router.post("/add",controller.postProduct)


module.exports = router;
 