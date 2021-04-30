import React from "react";
import PagePicker from "components/PagePicker"
import { useState } from "react"
import ShelterFilter from "../Filters/ShelterFilter"
import ShelterList from "./ShelterList"
import { ShelterListingWrapper } from "./index.styled";
import SortPicker from "components/Filters/SortPicker";

const SORT_OPTIONS = ["Lokaciji", "A-Z", "Z-A"];

const ShelterListing = () => {
  const [filterOptions, setFilterOptions] = useState();
  const [currentPage, setCurrentPage] = useState(1);
  const [sortType, setSortType] = useState(0);

  return (
    <ShelterListingWrapper>
      <div className="listing-options">
        <ShelterFilter setFilterOptions={setFilterOptions} />
        <SortPicker options={SORT_OPTIONS} value={sortType} setValue={setSortType} />
      </div>
      <PagePicker pageCount={4} currentPage={currentPage} setPage={setCurrentPage} />
      <ShelterList />
    </ShelterListingWrapper>
  )
}

export default ShelterListing;