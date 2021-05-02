import React from "react";
import { useState } from "react";
import RadioPicker from "./RadioPicker";
import StringInputPicker from "./StringInputPicker";
import { filterType } from "consts/enums";
import { FilterWrapper, FilterOption } from "./index.styled";
import closeIcon from "assets/svgs/cross.svg";
import MultiplePicker from "./MultiplePicker";
import { ANIMAL_ENUMS } from "consts/modelEnums";


const AnimalFilter = ({ filterProps, searchAction }) => {
  const {
    chosenSpecie, setChosenSpecie,
    chosenGender, setChosenGender,
    chosenAge, setChosenAge,
    chosenLocation, setChosenLocation } = filterProps;

  const [focus, setFocus] = useState(filterType.NONE);

  const closeModul = (e) => {
    e.stopPropagation();
    setFocus(setFocus(filterType.NONE));
  }

  return (
    <FilterWrapper className="shelter__filer">
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.SPECIE)} focused={focus === filterType.SPECIE}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Vrsta</p>
        <p className="filter-explain">Odaberi vrstu</p>
          <MultiplePicker values={chosenSpecie} setValues={setChosenSpecie} options={ANIMAL_ENUMS.specie} />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.GENDER)} focused={focus === filterType.GENDER}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Spol</p>
        <p className="filter-explain">Odaberi spol</p>
          <MultiplePicker values={chosenGender} setValues={setChosenGender} options={ANIMAL_ENUMS.gender} />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.AGE)} focused={focus === filterType.AGE}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Starost</p>
        <p className="filter-explain">Odaberi starost</p>
          <MultiplePicker values={chosenAge} setValues={setChosenAge} options={ANIMAL_ENUMS.age} />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.LOCATION)} focused={focus === filterType.LOCATION}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Lokacija</p>
        <p className="filter-explain">Upiši lokaciju</p>
        <StringInputPicker value={chosenLocation} setValue={setChosenLocation}
          className="filter-picker" placeholder="Upiši lokaciju" />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => searchAction()}>
        <p>Pretraži</p>
      </FilterOption>
    </FilterWrapper>
  )
}

export default AnimalFilter;