import React, { useState } from "react";
import SearchIcon from "../Assets/icons/zoom in.svg";
import FirstDog from "../Assets/slike/pas 1.png";
import SecondDog from "../Assets/slike/pas 2.png";
import ThirdDog from "../Assets/slike/pas 3.png";
import FourthDog from "../Assets/slike/pas 4.png";
import FifthDog from "../Assets/slike/pas 5.png";

import "./style.css";

const Gallery = () => {
  const [hover, setHover] = useState(false);

  const handleMouseOver = (e) => {
    setHover(true);
  };
  const handleMouseLeave = (e) => {
    setHover(false);
  };
  return (
    <div className="gallery">
      <img src={FirstDog} alt="dog-image-one" className="first-dog" />
      <div
        className="gallery-container"
        onMouseEnter={(e) => handleMouseOver()}
        onMouseLeave={(e) => handleMouseLeave()}
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
        <img className="gallery-image" src={SecondDog} alt="dog-image-two" />
        <img className="gallery-image" src={ThirdDog} alt="dog-image-three" />
        <img className="gallery-image" src={FourthDog} alt="dog-image-four" />
        <img className="gallery-image" src={FifthDog} alt="dog-image-five" />
      </div>
    </div>
  );
};

export default Gallery;
