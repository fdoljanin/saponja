import React from "react";
import Logo from "./Assets/logo.svg";
import Corgi from './Assets/header.png'
import Heart from './Assets/srce.svg'
import "./landingPage.css";

const LandingPage = () => {
  return (
    <body>
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
      <header>
        <div className="header__banner">
            <img src={Corgi} alt="Corgi" className="header__banner-dog"/>
            <img src={Heart} alt="heart" className="header__banner-heart" />
        </div>
      </header>
    </body>
  );
};

export default LandingPage;
