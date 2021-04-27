import React from "react";
import Paw from "../Assets/šapa.svg";
import "./formModal.css";

const FormModal = () => {
  return (
    <div className="form__modal">
      <div className="form__modal-container">
        <div className="form__modal-container-title">
          <div>
            <p>Želiš me udomiti?</p>
            <img src={Paw} alt="šapa" />
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
        <div className="form__modal-container-input">
          <div>
            <input className="modal-input" placeholder="Ime" />
            <input className="modal-input" placeholder="Prezime" />
            <input className="modal-input" placeholder="Email" />
            <input className="modal-input" placeholder="Adresa" />
          </div>
          <textarea rows="7" placeholder="Poruka" />
        </div>
        <div className="form__modal-container-button">
          <button>Pošalji</button>
        </div>
      </div>
    </div>
  );
};

export default FormModal;
