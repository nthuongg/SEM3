import logo from './logo.svg';
import './App.css';
import NavComponent from './components/shared/Nav';
import { Route, Routes } from 'react-router-dom';
import HomePage from './components/pages/Home';
import CategoryPage from './components/pages/Category';
import ProductPage from './components/pages/Product';
import RegisterPage from './components/pages/Register';
import ProductDetail from './components/pages/ProductDetail';

import STATE from './context/initState';
import { ContextProvider } from './context/context';
import { useReducer, useState } from 'react';
import reducer from './context/reducer';

function App() {
  const [state, dispatch] = useReducer(reducer,STATE);
  return (
    <ContextProvider value={{ state, dispatch }}>
      <div className="App">
        <NavComponent />
        <div className='content'>
          <Routes>
            <Route path='/' element={<HomePage />} />
            <Route path='/category' element={<CategoryPage />} />
            <Route path='/product' element={<ProductPage />} />
            <Route path='/product/:id' element={<ProductDetail />} />
            <Route path='/register' element={<RegisterPage />} />
          </Routes>
        </div>
      </div>
    </ContextProvider>

  );
}

export default App;
