import React from 'react';
import Corgi from "../Assets/header.png";
import Heart from "../Assets/srce.svg";
import CorgiMobile from '../Assets/corgi mobile crop.png';
import CorgiIpad from "../Assets/corgi mobile.png";

import "./style.css";

const Header = () => {
  return (
    <header>
      <div className="header__desktop">
      <img src={Corgi} alt="Corgi" className="header-dog" />
      <img src={Heart} alt="Heart" className="header-heart" />
      </div>
      <div className="header__mobile">
        <img src={CorgiIpad} alt="ipad corgi" className="ipad-corgi"/>
        <p>Šaponja</p>
        <img src={CorgiMobile} alt='mobile corgi'className="mobile-corgi"/>
      </div>
    </header>
  );
};

export default Header;
