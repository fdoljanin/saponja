import axios from "axios";
import React, { useState } from "react";
import Paw from "../../../assets/icons/šapa.svg";
import "./style.css";

const initialState = {
  adopter: {
    firstName: "",
    lastName: "",
    email: "",
    city: "",
    motivation: ""
  }
}

const FormModal = ({ showForm, onClose, animalId }) => {
  const [adopter, setAdopter] = useState(initialState.adopter);

  if (!showForm) {
    return null;
  }

  const handleChange = ({ target: { name, value } }) => {
    setAdopter((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post("api/Adopter/ApplyForAnimal", { ...adopter, animalId })
      .then(onClose)
  }

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
            onClick={onClose}
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
        <form className="form__modal-container-input" onSubmit={handleSubmit}>
          <div>
            <input className="modal-input" placeholder="Ime" name="firstName" onChange={handleChange} />
            <input className="modal-input" placeholder="Prezime" name="lastName" onChange={handleChange} />
            <input className="modal-input" placeholder="Email" name="email" onChange={handleChange} />
            <input className="modal-input" placeholder="Prebivalište" name="city" onChange={handleChange} />
          </div>
          <textarea rows="7" placeholder="Poruka" name="motivation" onChange={handleChange} />
          <div className="form__modal-container-button">
            <button type="submit">Pošalji</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default FormModal;
