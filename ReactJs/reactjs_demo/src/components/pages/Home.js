import React from "react";
import { Card, Col, Row } from "react-bootstrap";
import api from "../../services/api";
import { get_product } from "../../services/product.service";

class HomePage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            products: []
        }
    }

    async componentDidMount() {
        const products = await get_product(12);
        this.setState({products:products});
    }
    render() {
        const products = this.state.products;
        return (
            <div className="container">
                <h1>HomePage</h1>
                <Row>
                    {products.map(product => (
                        <Col xs={3} key={product.id}>
                            <Card.Img src={product.thumbnail} />
                            <Card.Body>
                                <Card.Title>{product.title}</Card.Title>
                                <Card.Title>{product.description}</Card.Title>
                            </Card.Body>
                            <Card.Footer>
                                <Card.Text>{product.price}</Card.Text>
                                <Card.Link className="btn btn-primary">
                                    Add to Cart
                                </Card.Link>
                            </Card.Footer>
                        </Col>
                    ))}

                </Row>
            </div>
        )
    }

}
export default HomePage;