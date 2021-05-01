import React from "react";
import Paw from 'assets/icons/šapa.svg';
import IsTrue from '../IsTrue';
import IsFalse from '../IsFalse';
import "./style.css";
import { ANIMAL_ENUMS } from "consts/modelEnums";
import { Link } from "react-router-dom";

const AnimalInformation = ({ animal }) => {

  const showTruethiness = (bool) => {
    return bool ? <IsTrue /> : <IsFalse />;
  }

  console.log(animal.specie);

  return (
    <div className="animal-info">
      <div className="animal-info-name">
        <p>{animal.name}</p>
        <img src={Paw} alt="sapa" />
      </div>
      <p>
        Vrsta: <span>{ANIMAL_ENUMS.specie[animal.specie]}</span>
      </p>
      <p>
        Spol: <span>{ANIMAL_ENUMS.gender[animal.gender]}</span>
      </p>
      <p>
        Starost: <span>{ANIMAL_ENUMS.age[animal.age]}</span>
      </p>
      <Link to={`/shelter/${animal.shelterId}`}>
      <p>
        Azil: <span className="shelter-info">{animal.shelterName}</span>
      </p>
      </Link>
      <p>
        Moja priča:{" "}
        <span className="animal-description">
          {animal.description}
        </span>
      </p>
      <div className="animal-info-check-container">
        <div>
          <div className="animal-info-check">
            {showTruethiness(animal.isSterilized)}
            <span>Steriliziran</span>
          </div>
          <div className="animal-info-check">
            {showTruethiness(animal.isVaccinated)}
            <span>Cijepljen</span>
          </div>
          <div className="animal-info-check">
            {showTruethiness(animal.isRequiredExperience)}
            <span>Zahtjeva iskustvo</span>
          </div>
        </div>
        <div>
          <div className="animal-info-check">
            {showTruethiness(animal.isGoodWithChildren)}
            <span>Dobar s djecom</span>
          </div>
          <div className="animal-info-check">
            {showTruethiness(animal.isGoodWithDogs)}
            <span>Dobar sa psima</span>
          </div>
          <div className="animal-info-check">
            {showTruethiness(animal.isGoodWithCats)}
            <span>Dobar s mačkama</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AnimalInformation;