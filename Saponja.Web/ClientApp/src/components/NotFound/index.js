import React from "react";
import LeftTears from 'assets/svgs/Group 334.svg';
import RightTears from 'assets/svgs/Group 335.svg';
import NotFoundDog from "assets/images/notfound-dog.png";
import Background from "assets/landingPage_assets/pozadina za bulldoga.svg";
import {NotFoundWrapper} from './index.styled.js';

const NotFound = () => {
  return (
    <NotFoundWrapper>
      <img src={Background} alt="not-found-background" className="not-found-background"/>
      <p className="error-number">404</p>
      <img src={NotFoundDog} alt="not-found-dog" className="not-found-dog"/>
      <img src={LeftTears} alt="tears left" className="tears-left" />
      <img src={RightTears} alt="tears right" className="tears-right" />
      <p className="error-message">NotFound</p>
    </NotFoundWrapper>
  );
};
export default NotFound;