import React from "react";
import AnimalCard from "./AnimalCard";
import { AnimalListWrapper } from "./index.styled";

const AnimalList = ({ animals }) => {
  return (
    <AnimalListWrapper>
      { animals.map(animal => 
      <AnimalCard animal={animal} key={animal.id} />) }
    </AnimalListWrapper>
  )
}

export default AnimalList;