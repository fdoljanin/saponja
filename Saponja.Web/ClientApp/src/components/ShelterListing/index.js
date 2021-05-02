import React, { useEffect, useState } from "react";
import { useHistory, useParams } from "react-router";
import axios from "axios";

import PagePicker from "components/PagePicker";
import ShelterFilter from "../Filters/ShelterFilter";
import ShelterList from "./ShelterList";
import SortPicker from "components/Filters/SortPicker";

import { SHELTER_DISTANCE_VALUES, SORT_TYPES } from "consts/modelEnums";
import { DEFAULT_GEOLOCATION } from "consts/constants";
import { getNumberOfPages } from "utils/mathHelpers";
import { ShelterListingWrapper } from "./index.styled";

const ShelterListing = () => {
  const params = useParams();
  const history = useHistory();

  const initialState = {
    location: params.location?.trim() || "",
    distance: +params.distance?.trim() || 0,
    name: params.name?.trim() || "",
    sortType: +params.sort?.trim() || 1,
    currentPage: +params.page?.trim() || 1
  }


  const [chosenLocation, setChosenLocation] = useState(initialState.location);
  const [chosenDistance, setChosenDistance] = useState(initialState.distance);
  const [chosenName, setChosenName] = useState(initialState.chosenName);

  const filterProps = {
    chosenLocation, setChosenLocation,
    chosenDistance, setChosenDistance,
    chosenName, setChosenName
  };

  const [sortType, setSortType] = useState(initialState.sortType);
  const [currentPage, setCurrentPage] = useState(initialState.currentPage);
  const [pageCount, setPageCount] = useState(0);

  const [geolocation, setGeolocation] = useState(DEFAULT_GEOLOCATION);
  navigator.geolocation.getCurrentPosition(p => setGeolocation(p.coords));

  const [filteredShelters, setFilteredShelters] = useState([]);

  const searchAction = () => {
    const props = {
      location: chosenLocation || " ",
      distance: chosenDistance,
      name: chosenName || " ",
      sort: sortType,
      page: currentPage
    }

    history.push(`/shelter/filter/${props.location}/${props.distance}/${props.name}/${props.sort}/${props.page}`);
  }

  useEffect(searchAction, [currentPage]);

  useEffect(() => {
    const filterModel = {
      city: chosenLocation,
      distanceInKilometers: SHELTER_DISTANCE_VALUES[chosenDistance],
      name: chosenName,
      sortType,
      pageNumber: currentPage - 1,
      userGeolocation: geolocation
    }

    axios.post("api/Visitor/GetFilteredShelters", filterModel)
      .then(({ data }) => {
        setPageCount(getNumberOfPages(data.sheltersCount));
        setFilteredShelters(data.shelters);
      });
  }, [params]);

  return (
    <ShelterListingWrapper>
      <div className="listing-options">
        <ShelterFilter filterProps={filterProps} searchAction={searchAction} />
        <SortPicker options={SORT_TYPES.shelter} value={sortType} setValue={setSortType} />
      </div>
      {pageCount ? <PagePicker pageCount={pageCount} currentPage={currentPage} setPage={setCurrentPage} /> : null}
      <ShelterList shelterList={filteredShelters} />
    </ShelterListingWrapper>
  )
}

export default ShelterListing;