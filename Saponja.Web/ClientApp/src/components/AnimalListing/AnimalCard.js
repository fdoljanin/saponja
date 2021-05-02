import React from "react";
import continueIcon from "assets/svgs/continue.svg";
import { AnimalCardWrapper } from "./index.styled";
import { ANIMAL_ENUMS } from "consts/modelEnums";
import { Link } from "react-router-dom";


const AnimalCard = ({ animal }) => {
  return (
    <AnimalCardWrapper>
      <img src={animal.profilePhotoPath} className="animal-photo" />
      <div className="animal-info">
        <h2 className="animal-name">{animal.name}</h2>
        <div className="animal-properties">
          <p className="animal-property"><b>Spol:</b> {ANIMAL_ENUMS.gender[animal.gender]}</p>
          <p><b>Starost:</b> {ANIMAL_ENUMS.age[animal.age]}</p>
          <p><b>Azil:</b> {animal.shelterName}</p>
        </div>
        <Link to={`/animal/${animal.id}`}>
          <img src={continueIcon} className="animal-continue" />
        </Link>
      </div >
    </AnimalCardWrapper >
  )
}

export default AnimalCard;