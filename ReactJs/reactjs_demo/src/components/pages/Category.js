import { useEffect, useState } from "react";
import { Card, Col, Row } from "react-bootstrap";
import { get_product } from "../../services/product.service";

function CategoryPage(){
    const [products, setProducts] = useState([]);
    const load_products = async ()=>{
        const rs = await get_product(8);
        setProducts(rs);
    }

    useEffect(()=> { // check sự thay đổi của các state
        load_products();                
    },[]); //  truyền mảng rỗng tức là tương đương componentDidMount  //chỉ chạy 1 lần duy nhất sau khi in ra giao diện
    return (
        <div className="container">
            <h1>CategoryPage</h1>
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
export default CategoryPage;