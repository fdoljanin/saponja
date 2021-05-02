import React, { useEffect, useState } from "react";
import Background from "../../../assets/animalDetails_assets/pozadina.svg";

import NavigationBar from "../../NavigationBar";
import Gallery from '../Gallery';
import AnimalInformation from '../AnimalInformation/AnimalInformation';
import FosteringInfo from '../FosteringInfo';
import Footer from "../../Footer";
import AnimalPhotosModal from '../AnimalPhotosModal';
import FormModal from '../FormModal';

import "./style.css";
import { useParams } from "react-router";
import axios from "axios";
import { useUser } from "services/providers/user/hooks";

const AnimalDetails = () => {
  const [show, setShow] = useState(false);
  const [showForm, setShowForm] = useState(false);
  const [animal, setAnimal] = useState();
  const { id: animalId } = useParams();

  const user = useUser();

  const handleShowForm = () => {
    setShowForm(true);
  }

  
  useEffect(() => {
    axios.get(`api/Visitor/GetAnimalDetails?animalId=${animalId}`)
    .then(({ data }) => setAnimal(data));
  }, []);
  
  if (!animal) {
    return <h1>Loading</h1>
  }
  
  const showAdoptPopupOrNull = () => {
    return animal.shelterId != user.id
      ? <FormModal onClose={() => setShowForm(false)} showForm={showForm} animalId={animalId} />
      : null;
  }
  
  return (
    <div>
      <div className="animal__details">
        <img
          src={Background}
          alt="pozadina"
          className="animal__details-background"
        />
        <div className="animal__details-container">
          <Gallery animal={animal} onShowGallery={() => setShow(true)} />
          <div className="animal__details-info-container">
            <AnimalInformation animal={animal} />
            <FosteringInfo onShowForm={handleShowForm} downloadLink={animal.documentationLink} />
          </div>
        </div>
      </div>
      <AnimalPhotosModal onClose={() => setShow(false)} shouldShow={show} animal={animal} />
      {showAdoptPopupOrNull}
    </div>
  );
};

export default AnimalDetails;