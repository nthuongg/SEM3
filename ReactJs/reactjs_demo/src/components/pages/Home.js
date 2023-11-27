import React from "react";
import { Card, Col, Row } from "react-bootstrap";

class HomePage extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            products : []
        }
    }

    componentDidMount() {
        //call api
        const url = `https://dummyjson.com/products?limit=12`;
        fetch(url).then(rs=>rs.json())
        .then(rs=>{
            this.setState({products: rs.products});
            console.log(rs);
        })
        .catch(err=>{console.log(err)});
    }
    render() {
        const products = this.state.products;
        return (
            <div className="container">
                <h1>HomePage</h1>
                <Row>
                    {products.map(product => (
                        <Col xs={3}>
                        <Card.Img src={product.thumbnail}/>
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