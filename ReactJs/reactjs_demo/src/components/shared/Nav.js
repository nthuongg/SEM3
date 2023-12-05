import { Link } from "react-router-dom";
import NavDropdown from 'react-bootstrap/NavDropdown';
import React, { useContext, useEffect, useState } from "react";
import Context from "../../context/context";

function NavComponent(props) {
  const [categories, setCategories] = useState([]);//useState được sử dụng để khởi tạo trạng thái categories, setCategories là hàm để cập nhật giá trị của trạng thái đó.
  
  useEffect(() => {
    const fetchCategories = async () => {

      try {
        const url = `https://dummyjson.com/products/categories`;
        const response = await fetch(url); //Gửi yêu cầu http và nhận phản hồi
        const data = await response.json(); //chuyển đổi sang dạng json
        setCategories(data); // Cập nhật trạng thái state
        console.log(data);
      } catch (error) {
        console.error(error);
      }
    }
    fetchCategories();
  }, []);
  const { state } = useContext(Context);

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
            <li className="nav-item">
              <Link to="/cart" className="nav-link">Cart ({state.cart.length})</Link>
            </li>
            <li className="nav-item">
              <Link to="/favorite" className="nav-link">Favorite ({state.favorite.length})</Link>
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

export default NavComponent;

