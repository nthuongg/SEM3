import { Link } from "react-router-dom";
import NavDropdown from 'react-bootstrap/NavDropdown';
import React from "react";

class NavComponent extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      categories: []
    };
  }

  componentDidMount() {
    //call api
    const url = `https://dummyjson.com/products/categories`;
    fetch(url) //gửi một yêu cầu HTTP và trả về một Promise chứa response từ server
      .then(rs => rs.json()) // Giải quyết Promise và chuyển đổi phản hồi sang dạng JSON
      .then(data => {
        this.setState({ categories: data });
        console.log(data);
      })
      .catch(err => {
        console.log(err);
      });
  }

  render() {
    const categories = this.state.categories;

    return (
      <nav className="navbar navbar-expand-lg bg-body-tertiary">
        <div className="container">
          <a className="navbar-brand" href="#">
            Navbar
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link to="/" className="nav-link">
                  Home
                </Link>
              </li>
              <li className="nav-item">
                <NavDropdown
                  id="nav-dropdown-dark-example"
                  title="Category"
                  menuVariant="light"
                >
                  {categories && categories.map(category => (
                    <NavDropdown.Item 
                    key={category} 
                    as={Link}
                    to={`/category/${category}`}
                    >                    
                      {category}
                    </NavDropdown.Item>
                  ))}
                </NavDropdown>
              </li>

              <li className="nav-item">
                <Link to="/product" className="nav-link">Product</Link>
              </li>
            </ul>
            <form className="d-flex" role="search">
              <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
              <button className="btn btn-outline-success" type="submit">Search</button>
            </form>
          </div>
        </div>
      </nav>
    )



  }
}

export default NavComponent;

