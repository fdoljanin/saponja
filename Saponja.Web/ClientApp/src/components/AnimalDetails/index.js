import React from "react";
import Logo from "./Assets/logo.svg";
import Background from './Assets/pozadina.svg';
import "./animalDetails.css";

const AnimalDetails = () => {
  return (
    <div>
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
      <div className="animal__details">
        <img src={Background} alt="pozadina" className="animal__details-background"/>
        <div className="animal__details-container">
          
        </div>
      </div>
    </div>
  );
};

export default AnimalDetails;
