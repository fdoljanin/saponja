import React from "react";
import { ShelterCardWrapper } from "./index.styled";
import { Link } from "react-router-dom";
import pawIcon from "assets/svgs/paw.svg";
import continueIcon from "assets/svgs/continue.svg";

const ShelterCard = ({ shelter }) => {
  return (
    <ShelterCardWrapper>
      <img src={pawIcon} className="card-image--paw" />
      <div className="card-header">
        <h2 className="card-title">{shelter.name}</h2>
        <Link to={shelter.websiteUrl}>
          <p className="card-link">{shelter.websiteUrl}</p>
        </Link>
      </div>
      <div className="card-info">
        <p>{shelter.city}</p>
        <p>{shelter.address}</p>
      </div>
      <div className="card-contact">
        <div className="card-info">
          <p>{shelter.contactPhone}</p>
          <p>Mail: <span>{shelter.contactEmail}</span></p>
        </div>
        <Link className="card-continue" to={`/shelter/${shelter.id}`}>
          <img src={continueIcon} />
        </Link>
      </div>

    </ShelterCardWrapper>
  )
}

export default ShelterCard;