import React, { useEffect } from "react";
import PagePicker from "components/PagePicker"
import { useState } from "react"
import ShelterFilter from "../Filters/ShelterFilter"
import ShelterList from "./ShelterList"
import { ShelterListingWrapper } from "./index.styled";
import SortPicker from "components/Filters/SortPicker";
import { useHistory, useParams } from "react-router";
import { history } from "utils/BrowserHistoryWrapper";
import axios from "axios";

const SORT_OPTIONS = ["Lokaciji", "A-Z", "Z-A"];
const LOCATION_VALUES = [35, 50, 75, 100, 25009];

const defaultGeolocation = {
  latitude: 43.508133,
  longitude: 16.440193
}

const ShelterListing = () => {
  const params = useParams();
  const history = useHistory();

  const [chosenLocation, setChosenLocation] = useState(params.location?.trim() || "");
  const [chosenDistance, setChosenDistance] = useState(+params.distance?.trim() || 0);
  const [chosenName, setChosenName] = useState(params.name?.trim() || "");

  const [sortType, setSortType] = useState(+params.sort?.trim() || 1);
  const [currentPage, setCurrentPage] = useState(+params.page?.trim() || 1);
  const [pageCount, setPageCount] = useState();

  const [geolocation, setGeolocation] = useState(defaultGeolocation);
  const [filteredShelters, setFilteredShelters] = useState([]);

  const filterProps = {
    chosenLocation, setChosenLocation,
    chosenDistance, setChosenDistance,
    chosenName, setChosenName
  };

  navigator.geolocation.getCurrentPosition(p => setGeolocation(p.coords));

  const searchAction = () => {
    history.push(`/shelter/filter/${chosenLocation || " "}/${chosenDistance || " "}/${chosenName || " "}/${sortType || " "}/${currentPage || " "}`);
  }

  useEffect(searchAction, [currentPage]);

  useEffect(() => {
    const shelterFilterModel = {
      city: chosenLocation,
      distanceInKilometers: LOCATION_VALUES[chosenDistance],
      name: chosenName,
      sortType,
      pageNumber: currentPage-1,
      userGeolocation: geolocation
    }

    axios.post("api/Visitor/GetFilteredShelters", shelterFilterModel)
    .then(({data}) => {
      setPageCount(Math.ceil(data.sheltersCount/3));
      setFilteredShelters(data.shelters);
    });
  }, [params]);

  return (
    <ShelterListingWrapper>
      <div className="listing-options">
        <ShelterFilter filterProps={filterProps} searchAction={searchAction} />
        <SortPicker options={SORT_OPTIONS} value={sortType} setValue={setSortType} />
      </div>
      {filteredShelters.length ? <PagePicker pageCount={pageCount} currentPage={currentPage} setPage={setCurrentPage} /> : null}
      <ShelterList shelterList={filteredShelters}/>
    </ShelterListingWrapper>
  )
}

export default ShelterListing;