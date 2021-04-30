import React from "react";
import { useState } from "react";
import RadioPicker from "./RadioPicker";
import StringInputPicker from "./StringInputPicker";
import { FilterWrapper, FilterOption } from "./index.styled";
import closeIcon from "assets/svgs/cross.svg";

const focusModes = {
  location: "location",
  name: "name",
  distance: "distance",
  none: "none"
}

const ShelterFilter = ({ filterProps, searchAction }) => {
  const { chosenLocation, setChosenLocation,
    chosenDistance, setChosenDistance,
    chosenName, setChosenName } = filterProps;

  const distanceOptions = ["35km ili manje", "50km ili manje", "75km ili manje", "100km ili manje", "250km ili manje"];
  const [focus, setFocus] = useState(focusModes.none);

  const closeModul = (e) => {
    e.stopPropagation();
    setFocus(focusModes.none);
  }

  return (
    <FilterWrapper className="shelter__filer">
      <FilterOption className="filter-option" onClick={() => setFocus(focusModes.location)} focused={focus === focusModes.location}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} />
        <p className="filter-name">Lokacija</p>
        <p className="filter-explain">Upiši lokaciju</p>
        <StringInputPicker value={chosenLocation} setValue={setChosenLocation}
          className="filter-picker" placeholder="Upiši lokaciju" />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(focusModes.distance)} focused={focus === focusModes.distance}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} />
        <p className="filter-name">Udaljenost</p>
        <p className="filter-explain">Odaberi daljinu</p>
        <RadioPicker value={chosenDistance} setValue={setChosenDistance}
          className="filter-picker" options={distanceOptions} />
      </FilterOption>
      <FilterOption className="filter-option" onClick={() => setFocus(focusModes.name)} focused={focus === focusModes.name}>
        <img src={closeIcon} className="filter-close" onClick={closeModul} />
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