import React, {useState} from "react";
import Background from "../../../assets/animalDetails_assets/pozadina.svg";

import NavigationBar from "../../NavigationBar";
import Gallery from '../Gallery';
import AnimalInformation from '../AnimalInformation/AnimalInformation';
import FosteringInfo from '../FosteringInfo';
import Footer from "../../Footer";
import AnimalPhotosModal from '../AnimalPhotosModal';
import FormModal from '../FormModal';

import "./style.css";

const AnimalDetails = () => { 
  const [show, setShow] = useState(false);
  const [showForm, setShowForm] = useState(false);

  const handleShowGallery = () => {
    setShow(true);
  }

  const handleShowForm = () => {
    setShowForm(true);
  }

  return (
    <div>
      <NavigationBar />
      <div className="animal__details">
        <img
          src={Background}
          alt="pozadina"
          className="animal__details-background"
        />
        <div className="animal__details-container">
          <Gallery onShowGallery={handleShowGallery}/>
          <div className="animal__details-info-container">
            <AnimalInformation />
            <FosteringInfo onShowForm={handleShowForm}/>
          </div>
        </div>
      </div>
      <Footer />
      <AnimalPhotosModal onClose={() => setShow(false)} show={show}/>
      <FormModal onClose={() => setShowForm(false)} showForm={showForm} />
    </div>
  );
};

export default AnimalDetails;
