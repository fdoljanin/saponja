import React, { useState, useEffect } from "react";
import { useHistory, useParams } from "react-router";
import axios from "axios";

import AnimalFilter from "components/Filters/AnimalFilter";
import PagePicker from "components/PagePicker";
import SortPicker from "components/Filters/SortPicker";
import AnimalList from "./AnimalList";

import { ANIMAL_ENUMS, SORT_TYPES } from "consts/modelEnums";
import { DEFAULT_GEOLOCATION } from "consts/constants";
import { getArrayFromBase32, getBase32FromArray, getSequenceFromArray } from "utils/arrayHelpers";
import { getNumberOfPages } from "utils/mathHelpers";
import { AnimalListingWrapper } from "./index.styled";

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

  useEffect(() => {
    if (currentPage !== 1)
      searchAction();
  }, [currentPage]);

  useEffect(() => {
    const filterModel = {
      specie: chosenSpecie,
      gender: chosenGender,
      age: chosenAge,
      location: chosenLocation.trim(),
      sortType,
      userGeolocation: geolocation,
      pageNumber: currentPage - 1
    }

    axios.post("api/Visitor/GetFilteredAnimals", filterModel)
      .then(({ data }) => {
        setFilteredAnimals(data.animals);
        setPageCount(getNumberOfPages(data.animalsCount));
      });
  }, [params]);

  return (
    <AnimalListingWrapper>
      <div className="listing-options">
        <AnimalFilter filterProps={filterProps} searchAction={searchAction} />
        <SortPicker options={SORT_TYPES.animal} value={sortType} setValue={setSortType} />
      </div>
      {pageCount ? <PagePicker pageCount={pageCount} currentPage={currentPage} setPage={setCurrentPage} /> : null}
      <AnimalList animals={filteredAnimals} />
    </AnimalListingWrapper>
  )
}

export default AnimalListing;