import { useContext, useEffect, useState } from "react";
import { detail_product } from "../../services/product.service";
import { useParams } from "react-router-dom";
import { Image, Col, Row, Form, Button } from 'react-bootstrap';
import React from "react";
import Context from "../../context/context";
import { ACTION } from "../../context/reducer";



function ProductDetail() {
  const [product, setProduct] = useState({});
  const { id } = useParams();
  const loadProduct = async () => {
    const rs = await detail_product(id);
    setProduct(rs);
  }
  useEffect(() => {
    loadProduct();
  }, [])

  const { state, dispatch } = useContext(Context);
  const addToCart = () => {
    let cart = state.cart;
    let check = true;
    cart.map(e => {
      if (e.id == product.id) {
        e.buy_qty = e.buy_qty + 1;
        check = false;
      }
      return e;
    })
    if (check) {
      product.buy_qty = 1;
      cart.push(product);
    }
    // state.cart = cart;
    // setState(state);
    //setState({...state,cart:cart});
    dispatch({ type: ACTION.UPDATE_CART, payload: cart });
  }

  const addFavorite = () => {
    let favorite = state.favorite;
    let check = true;
    favorite.map(e => {
      if (e.id == product.id) {
        e.buy_qty = e.buy_qty + 1;
        check = false;
      }
      return e;
    })
    if (check) {
      product.buy_qty = 1;
      favorite.push(product);
    }
   
    dispatch({ type: ACTION.UPDATE_FAVORITE, payload: favorite });
  }

  return (
    <section className="py-5">
      <div className="container">
        <Row className="gx-5">
          <Col lg={6}>
            <div className="border rounded-4 mb-3 d-flex justify-content-center">
              <a data-fslightbox="mygalley" className="rounded-4" target="_blank" data-type="image" >
                <Image style={{ maxWidth: '100%', maxHeight: '100vh', margin: 'auto' }} className="rounded-4 fit" src={product.thumbnail} />
              </a>
            </div>

          </Col>
          <Col lg={6}>
            <div className="ps-lg-3">
              <h4 className="title text-dark">
                {product.title}
              </h4>

              <div className="mb-3">
                <span className="h5">{product.price} $</span>
              </div>
              <p>
                {product.description}
              </p>
              <Row>
                <Col >
                  <Form.Label>Discount:</Form.Label>
                  <Form.Text> {product.discountPercentage}%</Form.Text>
                </Col>
                <Col >
                  <Form.Label>Rating:</Form.Label>
                  <Form.Text> {product.rating}</Form.Text>
                </Col>
              </Row>
              <Row>
                <Col >
                  <Form.Label>Stock:</Form.Label>
                  <Form.Text> {product.stock}</Form.Text>
                </Col>
                <Col >
                  <Form.Label>Brand:</Form.Label>
                  <Form.Text> {product.brand}</Form.Text>
                </Col>
              </Row>
              <hr />


              <div>Quantity</div>
              <div className="input-group mb-3 mx-auto" style={{ width: '100px' }}>
                <Form.Control
                  type="number"
                  className="text-center border border-secondary"
                  defaultValue={1}
                />
              </div>

              <Button href="#" variant="warning" className="shadow-0">
                Buy now
              </Button>
              <Button onClick={addToCart} variant="primary" className="shadow-0 ms-2">
                <i className="me-1 fa fa-shopping-basket"></i> Add to cart
              </Button>
              <Button onClick={addFavorite} variant="light" className="border border-secondary py-2 icon-hover px-3 ms-2">
                <i className="me-1 fa fa-heart fa-lg"></i> Save
              </Button>
            </div>
          </Col>
        </Row>
      </div>
    </section>
  )
}
export default ProductDetail;
