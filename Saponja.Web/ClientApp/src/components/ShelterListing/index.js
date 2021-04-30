import React, { useEffect } from "react";
import PagePicker from "components/PagePicker"
import { useState } from "react"
import ShelterFilter from "../Filters/ShelterFilter"
import ShelterList from "./ShelterList"
import { ShelterListingWrapper } from "./index.styled";
import SortPicker from "components/Filters/SortPicker";
import { useHistory, useParams } from "react-router";
import { history } from "utils/BrowserHistoryWrapper";

const SORT_OPTIONS = ["Lokaciji", "A-Z", "Z-A"];

const ShelterListing = () => {
  const params = useParams();
  const history = useHistory();

  const [chosenLocation, setChosenLocation] = useState(params.location?.trim() || "");
  const [chosenDistance, setChosenDistance] = useState(+params.distance?.trim() || 0);
  const [chosenName, setChosenName] = useState(params.name?.trim() || "");

  const [sortType, setSortType] = useState(+params.sort?.trim() || 1);
  const [currentPage, setCurrentPage] = useState(+params.page?.trim() || 1);

  const filterProps = {
    chosenLocation, setChosenLocation,
    chosenDistance, setChosenDistance,
    chosenName, setChosenName
  };

  const searchAction = () => {
    history.push(`/shelter/filter/${chosenLocation || " "}/${chosenDistance || " "}/${chosenName || " "}/${sortType || " "}/${currentPage || " "}`);
  }

  useEffect(searchAction, [currentPage]);

  useEffect(() => console.log("AAA"), [params]);

  return (
    <ShelterListingWrapper>
      <div className="listing-options">
        <ShelterFilter filterProps={filterProps} searchAction={searchAction} />
        <SortPicker options={SORT_OPTIONS} value={sortType} setValue={setSortType} />
      </div>
      <PagePicker pageCount={4} currentPage={currentPage} setPage={setCurrentPage} />
      <ShelterList />
    </ShelterListingWrapper>
  )
}

export default ShelterListing;