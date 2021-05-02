import React, { useState } from "react";
import SearchIcon from "../../../assets/icons/zoom in.svg";
import FirstDog from "../../../assets/animalDetails_assets/dog_images/pas 1.png";
import SecondDog from "../../../assets/animalDetails_assets/dog_images/pas 2.png";
import ThirdDog from "../../../assets/animalDetails_assets/dog_images/pas 3.png";
import FourthDog from "../../../assets/animalDetails_assets/dog_images/pas 4.png";
import FifthDog from "../../../assets/animalDetails_assets/dog_images/pas 5.png";

import "./style.css";

const Gallery = ({onShowGallery}) => {
  const [hover, setHover] = useState(false);

  const handleMouseOver = (e) => {
    setHover(true);
  };
  const handleMouseLeave = (e) => {
    setHover(false);
  };
  return (
    <div className="gallery">
      <img src={FirstDog} alt="dog-one" className="first-animal" />
      <div
        className="gallery-container"
        onMouseEnter={(e) => handleMouseOver()}
        onMouseLeave={(e) => handleMouseLeave()}
        onClick={onShowGallery}
      >
        <div
          className={
            hover ? "search-bar-container--hovered" : "search-bar-container"
          }
        >
          <div className={hover ? "" : "search-box"}>
            <img
              src={SearchIcon}
              alt="search-icon"
              className={hover ? "search--hovered" : "search"}
            />
          </div>
          <p className={hover ? "search-text--hovered" : "search-text"}>
            Pogledaj galeriju
          </p>
        </div>
        <div className="gallery-container-grid">
          <img className="gallery-image" src={SecondDog} alt="dog-two" />
          <img className="gallery-image" src={ThirdDog} alt="dog-three" />
          <img className="gallery-image" src={FourthDog} alt="dog-four" />
          <img className="gallery-image" src={FifthDog} alt="dog-five" />
        </div>
      </div>
    </div>
  );
};

export default Gallery;
