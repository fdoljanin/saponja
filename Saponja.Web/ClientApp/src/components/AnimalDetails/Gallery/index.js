import React, { useState } from "react";
import SearchIcon from "../../../assets/icons/zoom in.svg";
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
