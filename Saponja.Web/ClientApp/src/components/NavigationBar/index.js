import React from "react";
import Logo from './Assets/logo.svg';
import './navigationBar.css';

const NavigationBar = () => {
  return (
    <nav>
      <div className="logo__container">
        <img src={Logo} alt="saponja" />
      </div>
      <div className="title__container">
        <button>Naslovnica</button>
        <button>Udomi</button>
        <button>Azili</button>
        <button>Novosti</button>
        <button>Doniraj</button>
        <button>Prijavi se</button>
      </div>
    </nav>
  );
};

export default NavigationBar;
