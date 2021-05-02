import React, { useState } from "react";

import NavigationBar from '../../NavigationBar';
import Header from '../Header';
import Banner from '../Banner';
import Posts from '../Posts';
import BottomSection from '../BottomSection';
import Footer from '../../Footer';
import './style.css';
import AnimalFilter from "components/Filters/AnimalFilter";
import { getBase32FromArray, getSequenceFromArray } from "utils/arrayHelpers";
import { ANIMAL_ENUMS } from "consts/modelEnums";
import { useHistory } from "react-router";

const initialState = {
  filter: {
    specie: getSequenceFromArray(ANIMAL_ENUMS.specie),
    gender: getSequenceFromArray(ANIMAL_ENUMS.gender),
    age: getSequenceFromArray(ANIMAL_ENUMS.age),
    location: ""
  }
}

const MainScreen = () => {
  const [chosenSpecie, setChosenSpecie] = useState(initialState.filter.specie);
  const [chosenGender, setChosenGender] = useState(initialState.filter.gender);
  const [chosenAge, setChosenAge] = useState(initialState.filter.age);
  const [chosenLocation, setChosenLocation] = useState(initialState.filter.location);
  const history = useHistory();

  const filterProps = {
    chosenSpecie, setChosenSpecie,
    chosenGender, setChosenGender,
    chosenAge, setChosenAge,
    chosenLocation, setChosenLocation,
  };

  const searchAction = () => {
    const props = {
      specie: getBase32FromArray(chosenSpecie) || " ",
      gender: getBase32FromArray(chosenGender) || " ",
      age: getBase32FromArray(chosenAge) || " ",
      location: chosenLocation.trim() || " "
    };

    history.push(`/animal/filter/${props.specie}/${props.gender}/${props.age}/${props.location}`);
  }


  return (
    <main className="landing-main">
      <AnimalFilter filterProps={filterProps} searchAction={searchAction}/>
      <Header />
      <Banner />
      <Posts />
      <BottomSection />
    </main>
  );
};

export default MainScreen;
