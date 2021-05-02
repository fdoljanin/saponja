import React, { useState } from "react";
import SearchIcon from "../../../assets/icons/zoom in.svg";
import FirstDog from "../../../assets/animalDetails_assets/dog_images/pas 1.png";
import SecondDog from "../../../assets/animalDetails_assets/dog_images/pas 2.png";
import ThirdDog from "../../../assets/animalDetails_assets/dog_images/pas 3.png";
import FourthDog from "../../../assets/animalDetails_assets/dog_images/pas 4.png";
import FifthDog from "../../../assets/animalDetails_assets/dog_images/pas 5.png";

import "./style.css";

const Gallery = ({ animal, onShowGallery }) => {
  const [hover, setHover] = useState(false);

  return (
    <div className="gallery">
      <img src={animal.profilePhotoPath} alt="dog-one" className="first-animal" />
      <div
        className="gallery-container"
        onMouseEnter={() => setHover(true)}
        onMouseLeave={() => setHover(false)}
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
          {animal.galleryPhotoPaths.map(path =>
            <img className="gallery-image" src={path} key={path} />)
          }
        </div>
      </div>
    </div>
  );
};

export default Gallery;
