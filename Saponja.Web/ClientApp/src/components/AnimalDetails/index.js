import React from "react";
import Logo from "./Assets/logo.svg";
import Background from "./Assets/pozadina.svg";
import FirstDog from "./Assets/slike/pas 1.jpg";
import SecondDog from "./Assets/slike/pas 2.jpg";
import ThirdDog from "./Assets/slike/pas 3.jpg";
import FourthDog from "./Assets/slike/pas 4.jpg";
import FifthDog from "./Assets/slike/pas 5.jpg";
import Paw from "./Assets/šapa.svg";
import True from "./True";
import False from "./False";
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
        <img
          src={Background}
          alt="pozadina"
          className="animal__details-background"
        />
        <div className="animal__details-container">
          <div className="animal__details-container-images">
            <img src={FirstDog} alt="dog-image-one" className="first-dog" />
            <div className="animal__details-container-image-gallery">
              <img src={SecondDog} alt="dog-image-two" />
              <img src={ThirdDog} alt="dog-image-three" />
              <img src={FourthDog} alt="dog-image-four" />
              <img src={FifthDog} alt="dog-image-five" />
            </div>
          </div>
          <div className="animal__details-info-container">
            <div className="animal__details-animal-info">
              <div className="animal__details-animal-info-name">
                <p>Špiro</p>
                <img src={Paw} alt="sapa" />
              </div>
              <p>
                Vrsta: <span>Pas</span>
              </p>
              <p>
                Spol: <span>Muško</span>
              </p>
              <p>
                Starost: <span>6-12 mjeseci</span>
              </p>
              <p>
                Azil: <span className="shelter-info">Dumovec</span>
              </p>
              <p>
                Moja priča:{" "}
                <span className="animal-description">
                  Špiro ima 11 mjeseci, naučen je na kućni red, slaže se sa
                  ostalim pesekima i macama, ljude obožava a za djecu ima
                  posebnu ljubav! Obožava se maziti i davati puse, vrlo je
                  poslušan, sluša naredbe te lijepo hoda na povodcu. Potpuno je
                  veterinarski obrađen te čeka na kastraciju. U početku je bio
                  strašno nepovjerljiv prema ljudima, no sada, mjesec dana od
                  preuzimanja, on je pokazao da je najnježniji pas na svijetu!
                </span>
              </p>
              <div className="animal__details-animal-info-check-container">
                <div>
                  <div className="animal__details-animal-info-check">
                    <False />
                    <span>Steriliziran</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <True />
                    <span>Cijepljen</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <True />
                    <span>Zahtjeva iskustvo</span>
                  </div>
                </div>
                <div>
                  <div className="animal__details-animal-info-check">
                    <True />
                    <span>Dobar s djecom</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <False />
                    <span>Dobar s psima</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <False />
                    <span>Dobar s mačkama</span>
                  </div>
                </div>
              </div>
            </div>
            <div className="animal__details-foster-info"></div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AnimalDetails;
