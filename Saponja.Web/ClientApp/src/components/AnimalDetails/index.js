import React from "react";
import Logo from "./Assets/logo.svg";
import Background from './Assets/pozadina.svg';
import FirstDog from './Assets/slike/pas 1.jpg';
import SecondDog from './Assets/slike/pas 2.jpg';
import ThirdDog from './Assets/slike/pas 3.jpg';
import FourthDog from './Assets/slike/pas 4.jpg';
import FifthDog from './Assets/slike/pas 5.jpg';
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
          <div className="animal__details-container-images">
          <img src={FirstDog} alt="dog-image-one" className="first-dog"/>
          <div className="animal__details-container-image-gallery">
            <img src={SecondDog} alt="dog-image-two"/>
            <img src={ThirdDog} alt="dog-image-three"/>
            <img src={FourthDog} alt="dog-image-four"/>
            <img src={FifthDog} alt="dog-image-five"/>
          </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AnimalDetails;
