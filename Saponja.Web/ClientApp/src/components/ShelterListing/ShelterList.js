import React from "react";
import ShelterCard from "./ShelterCard";
import { ShelterListWrapper } from "./index.styled";


const ShelterList = () => {
  return (
    <ShelterListWrapper>
      <ShelterCard />
      <ShelterCard />
      <ShelterCard />
    </ShelterListWrapper>
  )
}

export default ShelterList;