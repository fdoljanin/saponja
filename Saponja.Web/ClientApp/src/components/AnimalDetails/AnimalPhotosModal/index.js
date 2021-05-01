import React, { useState } from "react";
import "./style.css";
import Paw from "../../../assets/icons/šapa.svg"
import FirstDog from "../../../assets/animalDetails_assets/dog_images/pas 1.png";
import SecondDog from "../../../assets/animalDetails_assets/dog_images/pas 2.png";
import ThirdDog from "../../../assets/animalDetails_assets/dog_images/pas 3.png";
import FourthDog from "../../../assets/animalDetails_assets/dog_images/pas 4.png";
import FifthDog from "../../../assets/animalDetails_assets/dog_images/pas 5.png";

const AnimalPhotosModal = props => {
  const [index, setIndex] = useState(0);
  const photos = [FirstDog, SecondDog, ThirdDog, FourthDog, FifthDog];

  if(!props.show) {
    return null;
  }

  const checkNumber = (number) => {
    if (number > photos.length - 1) {
      return 0;
    }
    if (number < 0) {
      return photos.length - 1;
    }
    return number;
  };

  const handleClickLeft = () => {
    setIndex(index => checkNumber(index - 1));
  };
  const handleClickRight = () => {
    setIndex(index => checkNumber(index + 1));
  };

  return (
    <div className="animal__photos">
      <div className="arrow-container">
        <div className="left-arrow" onClick={handleClickLeft}>
          <svg
            id="Filled"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            width="16px"
            height="16px"
          >
            <title>169 arrow left</title>
            <path
              fill="#fdfffd"
              d="M17.879,1.707A1,1,0,0,0,16.465.293L8.293,8.465a5,5,0,0,0,0,7.07l8.172,8.172a1,1,0,0,0,1.414-1.414L9.707,14.121a3,3,0,0,1,0-4.242Z"
              stroke="#fdfffd"
              strokeWidth="2px"
            />
          </svg>
        </div>
        <div className="animal__photos-container">
          <div className="animal__photos-container-title">
            <div>
              <p>Špiro</p>
              <img src={Paw} alt="šapa" />
            </div>
            <svg
              id="Filled"
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 24 24"
              width="16px"
              height="16px"
              onClick={props.onClose}
            >
              <title>180 cross</title>
              <path
                fill="#91B2CB"
                d="M13.414,12,23.707,1.707A1,1,0,0,0,22.293.293L12,10.586,1.707.293A1,1,0,0,0,.293,1.707L10.586,12,.293,22.293a1,1,0,0,0,0,1.414h0a1,1,0,0,0,1.414,0L12,13.414,22.293,23.707a1,1,0,0,0,1.414,0h0a1,1,0,0,0,0-1.414Z"
                stroke="#91B2CB"
                strokeWidth="2px"
              />
            </svg>
          </div>
          <img src={photos[index]} alt="dog" className="dog-image"/>
        </div>
        <div className="right-arrow" onClick={handleClickRight}>
          <svg
            id="Filled"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            width="16px"
            height="16px"
          >
            <title>168 arrow right</title>
            <path
              fill="#fdfffd"
              d="M6.293,22.293a1,1,0,1,0,1.414,1.414l8.172-8.172a5.005,5.005,0,0,0,0-7.07L7.707.293A1,1,0,0,0,6.293,1.707l8.172,8.172a3,3,0,0,1,0,4.242Z"
              stroke="#fdfffd"
              strokeWidth="2px"
            />
          </svg>
        </div>
      </div>
    </div>
  );
};

export default AnimalPhotosModal;
