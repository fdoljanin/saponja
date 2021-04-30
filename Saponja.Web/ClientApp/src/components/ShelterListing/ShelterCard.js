import React from "react";
import {ShelterCardWrapper} from "./index.styled";
import {Link} from "react-router-dom";
import pawIcon from "assets/svgs/paw.svg";
import continueIcon from "assets/svgs/continue.svg";

const ShelterCard = () => {
  return (
    <ShelterCardWrapper>
      <img src={pawIcon} className="card-image--paw" />
      <div className="card-header">
        <h2 className="card-title">Sklonište šapa</h2>
        <Link path="www.facebook.com">
        <p className="card-link">www.drustvo-sapa.hr</p>
        </Link>
      </div>
      <div className="card-info">
        <p>43 000 Bjelovar</p>
        <p>Letičani 5</p>
      </div>
      <div className="card-contact">
        <div className="card-info">
          <p>Telefon: 060 860 860</p>
          <p>Mail: <span>info@drustvo-sapa.hr</span></p>
        </div>
        <Link className="card-continue">
          <img src={continueIcon} />
        </Link>
      </div>

    </ShelterCardWrapper>
  )
}

export default ShelterCard;