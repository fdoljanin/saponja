import React, {useState} from 'react';
import './animalPhotosModal.css';
import Paw from '../Assets/šapa.svg';
import FirstDog from "../Assets/slike/pas 1.png";
import SecondDog from "../Assets/slike/pas 2.png";
import ThirdDog from "../Assets/slike/pas 3.png";
import FourthDog from "../Assets/slike/pas 4.png";
import FifthDog from "../Assets/slike/pas 5.png";


const AnimalPhotosModal = () => {

  const[index, setIndex] = useState(0);
  const photos = [FirstDog, SecondDog, ThirdDog, FourthDog, FifthDog];

  return (
    <div className="animal__photos">
      <div className="animal__photos-container">
        <div className="animal__photos-container-title">
          <div>
            <p>Špiro</p>
            <img src={Paw} alt="šapa"/>
          </div>
          <svg
            id="Filled"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 24 24"
            width="16px"
            height="16px"
          >
            <title>180 cross</title>
            <path
              fill="#91B2CB"
              d="M13.414,12,23.707,1.707A1,1,0,0,0,22.293.293L12,10.586,1.707.293A1,1,0,0,0,.293,1.707L10.586,12,.293,22.293a1,1,0,0,0,0,1.414h0a1,1,0,0,0,1.414,0L12,13.414,22.293,23.707a1,1,0,0,0,1.414,0h0a1,1,0,0,0,0-1.414Z"
              stroke="#91B2CB"
              stroke-width="3px"
            />
          </svg>
        </div>
        <img src={photos[index]} alt="dog-image"/>
      </div>
    </div>
  )
}

export default AnimalPhotosModal;