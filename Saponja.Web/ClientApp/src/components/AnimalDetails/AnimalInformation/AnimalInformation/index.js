import React from "react";
import Paw from '../../../../assets/icons/šapa.svg';
import IsTrue from '../IsTrue';
import IsFalse from '../IsFalse';
import "./style.css";

const AnimalInformation = () => {
  return (
    <div className="animal-info">
      <div className="animal-info-name">
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
          Špiro ima 11 mjeseci, naučen je na kućni red, slaže se sa ostalim
          pesekima i macama, ljude obožava a za djecu ima posebnu ljubav!
          Obožava se maziti i davati puse, vrlo je poslušan, sluša naredbe te
          lijepo hoda na povodcu. Potpuno je veterinarski obrađen te čeka na
          kastraciju. U početku je bio strašno nepovjerljiv prema ljudima, no
          sada, mjesec dana od preuzimanja, on je pokazao da je najnježniji pas
          na svijetu!
        </span>
      </p>
      <div className="animal-info-check-container">
        <div>
          <div className="animal-info-check">
            <IsFalse />
            <span>Steriliziran</span>
          </div>
          <div className="animal-info-check">
            <IsTrue />
            <span>Cijepljen</span>
          </div>
          <div className="animal-info-check">
            <IsFalse />
            <span>Zahtjeva iskustvo</span>
          </div>
        </div>
        <div>
          <div className="animal-info-check">
            <IsTrue />
            <span>Dobar s djecom</span>
          </div>
          <div className="animal-info-check">
            <IsTrue />
            <span>Dobar s psima</span>
          </div>
          <div className="animal-info-check">
            <IsFalse />
            <span>Dobar s mačkama</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AnimalInformation;