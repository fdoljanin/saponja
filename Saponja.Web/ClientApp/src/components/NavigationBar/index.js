import React from "react";
import Logo from '../../assets/navigationBar_assets/logo.svg';
import MobileLogo from "../../assets/navigationBar_assets/logo mobile.svg";
import Hamburger from '../../assets/icons/icon menu burger.svg';
import './style.css';

const NavigationBar = () => {
  return (
    <nav>
        <div className="logo__container">
          <img src={Logo} alt="saponja" className="logo__container-logo"/>
          <img src={MobileLogo} alt="saponja mobilni" className="logo__container-mobile-logo"/>
        </div>
        <div className="title__container">
          <button>Naslovnica</button>
          <button>Udomi</button>
          <button>Azili</button>
          <button>Novosti</button>
          <button>Doniraj</button>
          <button>Prijavi se</button>
          <img src={Hamburger} alt="hamburger" className="title__container-hamburger"/>
        </div>
      </nav>
  );
};

export default NavigationBar;
