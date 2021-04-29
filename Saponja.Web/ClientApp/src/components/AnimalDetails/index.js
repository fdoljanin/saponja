import React, { useState } from "react";
import Background from "./Assets/pozadina.svg";
import Paw from "./Assets/šapa.svg";

import Gallery from './Gallery';
import True from "./True";
import False from "./False";
import Footer from "../Footer";
import NavigationBar from "../NavigationBar";
import "./animalDetails.css";

const AnimalDetails = () => {
  const [hover, setHover] = useState(false);

  const handleMouseOver = (e) => {
    setHover(true);
  };
  const handleMouseLeave = (e) => {
    setHover(false);
  };

  return (
    <div>
      <NavigationBar />
      <div className="animal__details">
        <img
          src={Background}
          alt="pozadina"
          className="animal__details-background"
        />
        <div className="animal__details-container">
          <Gallery />
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
                    <False />
                    <span>Zahtjeva iskustvo</span>
                  </div>
                </div>
                <div>
                  <div className="animal__details-animal-info-check">
                    <True />
                    <span>Dobar s djecom</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <True />
                    <span>Dobar s psima</span>
                  </div>
                  <div className="animal__details-animal-info-check">
                    <False />
                    <span>Dobar s mačkama</span>
                  </div>
                </div>
              </div>
            </div>
            <div className="animal__details-foster-info">
              <h6>Želiš me udomiti?</h6>
              <p>Sve možeš odraditi iz udobnosti svoga doma!</p>
              <p>
                Sve što trebaš učiniti je javiti se da si zainteresiran,
                ispuniti podatke i kada je sve dogovoreno, bit ćeš obavješten
                putem maila s daljnjim uputama i potrebnom dokumentacijom.
              </p>
              <p>
                Potrebnu dokumentaciju možeš i odmah preuzeti{" "}
                <span>ovdje.</span>
              </p>
              <button>Raspitaj se</button>
              <p className="animal__details-foster-info-bottom-text">
                Možeš i direktno kontaktirati moj azil, kontakt podacima možeš
                prisutpiti na njihovom profilu.
              </p>
            </div>
          </div>
        </div>
      </div>
      <Footer />
    </div>
  );
};

export default AnimalDetails;
