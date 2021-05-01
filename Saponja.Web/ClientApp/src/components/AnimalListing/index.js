import React, { useState } from "react";
import AnimalFilter from "components/Filters/AnimalFilter";
import PagePicker from "components/PagePicker";
import { ANIMAL_ENUMS, SORT_TYPES } from "consts/modelEnums";
import { useHistory, useParams } from "react-router";
import { getArrayFromBase32, getBase32FromArray, getSequenceFromArray } from "utils/arrayHelpers";
import SortPicker from "components/Filters/SortPicker";
import { AnimalListingWrapper } from "./index.styled";
import { DEFAULT_GEOLOCATION } from "consts/constants";

const AnimalListing = () => {
  const params = useParams();
  const history = useHistory();

  const initialState = {
    specie: getArrayFromBase32(params.specie?.trim()) || getSequenceFromArray(ANIMAL_ENUMS.specie),
    gender: getArrayFromBase32(params.gender?.trim()) || getSequenceFromArray(ANIMAL_ENUMS.gender),
    age: getArrayFromBase32(params.age?.trim()) || getSequenceFromArray(ANIMAL_ENUMS.age),
    location: params.location?.trim() || "",
    sortType: +params.sort?.trim() || 1,
    currentPage: +params.page?.trim() || 1
  }

  const [chosenSpecie, setChosenSpecie] = useState(initialState.specie);
  const [chosenGender, setChosenGender] = useState(initialState.gender);
  const [chosenAge, setChosenAge] = useState(initialState.age);
  const [chosenLocation, setChosenLocation] = useState(initialState.location);

  const filterProps = {
    chosenSpecie, setChosenSpecie,
    chosenGender, setChosenGender,
    chosenAge, setChosenAge,
    chosenLocation, setChosenLocation,
  };

  const [sortType, setSortType] = useState(initialState.sortType);
  const [currentPage, setCurrentPage] = useState(initialState.currentPage);
  const [pageCount, setPageCount] = useState(0);

  const [geolocation, setGeolocation] = useState(DEFAULT_GEOLOCATION);
  navigator.geolocation.getCurrentPosition(p => setGeolocation(p.coords));
  
  const [filteredAnimals, setFilteredAnimals] = useState([]);

  const searchAction = () => {
    const props = {
      specie: getBase32FromArray(chosenSpecie) || " ",
      gender: getBase32FromArray(chosenGender) || " ",
      age: getBase32FromArray(chosenAge) || " ",
      location: chosenLocation.trim() || " ",
      sort: sortType,
      page: currentPage
    }

    history.push(`/animal/filter/${props.specie}/${props.gender}/${props.age}/${props.location}/${props.sort}/${props.page}`);
  }

  useEffect(searchAction, [currentPage]);

  return (
    <AnimalListingWrapper>
      <div className="listing-options">
        <AnimalFilter filterProps={filterProps} searchAction={searchAction} />
        <SortPicker options={SORT_TYPES.animal} value={sortType} setValue={setSortType} />
      </div>
      {pageCount ? <PagePicker pageCount={pageCount} currentPage={currentPage} setPage={setCurrentPage} /> : null}
    </AnimalListingWrapper>
  )
}

export default AnimalListing;