import React from 'react';
import Corgi from "../../../assets/landingPage_assets/header.png";
import Heart from "../../../assets/landingPage_assets/srce.svg";
import CorgiMobile from '../../../assets/landingPage_assets/corgi mobile crop.png';
import CorgiIpad from "../../../assets/landingPage_assets/corgi mobile.png";

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
