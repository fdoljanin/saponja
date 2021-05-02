import React from "react";
import ShelterCard from "./ShelterCard";
import { ShelterListWrapper } from "./index.styled";


const ShelterList = ({shelterList}) => {
  return (
    <ShelterListWrapper className="shelter__list">
      {shelterList.map(shelter => <ShelterCard shelter={shelter} key={shelter.id}/>)}
    </ShelterListWrapper>
  )
}

export default ShelterList;