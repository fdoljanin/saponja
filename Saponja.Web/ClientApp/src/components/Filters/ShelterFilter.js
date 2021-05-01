import React from "react";
import { useState } from "react";
import RadioPicker from "./RadioPicker";
import StringInputPicker from "./StringInputPicker";
import { FilterWrapper, FilterOption } from "./index.styled";
import closeIcon from "assets/svgs/cross.svg";
import { filterType } from "consts/enums";


const ShelterFilter = ({ filterProps, searchAction }) => {
  const { chosenLocation, setChosenLocation,
    chosenDistance, setChosenDistance,
    chosenName, setChosenName } = filterProps;

  const [focus, setFocus] = useState(filterType.NONE);

  const closeModul = (e) => {
    e.stopPropagation();
    setFocus(filterType.NONE);
  }

  return (
    <FilterWrapper className="shelter__filer">
      <FilterOption className="filter-option" onClick={() => setFocus(filterfilterType.LOCATION)} focused={focus === filterType.LOCATION}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Lokacija</p>
        <p className="filter-explain">Upiši lokaciju</p>
        <StringInputPicker value={chosenLocation} setValue={setChosenLocation}
          className="filter-picker" placeholder="Upiši lokaciju" />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.DISTANCE)} focused={focus === filterType.DISTANCE}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Udaljenost</p>
        <p className="filter-explain">Odaberi daljinu</p>
        <RadioPicker value={chosenDistance} setValue={setChosenDistance}
          className="filter-picker" options={distanceOptions} />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(filterType.NAME)} focused={focus === filterType.NAME}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} alt="Close module sign" />
        <p className="filter-name">Naziv</p>
        <p className="filter-explain">Upiši naziv</p>
        <StringInputPicker value={chosenName} setValue={setChosenName}
          className="filter-picker" placeholder="Upiši naziv" />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => searchAction()}>
        <p>Pretraži</p>
      </FilterOption>
    </FilterWrapper>
  )
}

export default ShelterFilter;