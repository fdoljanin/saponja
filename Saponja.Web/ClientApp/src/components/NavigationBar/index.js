import React from "react";
import { Link, useLocation } from 'react-router-dom';

import Logo from '../../assets/navigationBar_assets/logo.svg';
import MobileLogo from "../../assets/navigationBar_assets/logo mobile.svg";
import Hamburger from '../../assets/icons/icon menu burger.svg';
import { NavBarWrapper } from "./index.styled.js";

const reversedPaths = ["login", "donate", "news", "shelter", "animal", ""];

const NavigationBar = () => {
  const { pathname: currentPath } = useLocation();
  const currentSectionIndex = reversedPaths.length - reversedPaths.findIndex(p => currentPath.includes(p));

  return (
    <NavBarWrapper currentSection={currentSectionIndex}>
      <Link to="/">
        <div className="logo__container">
          <img src={Logo} alt="saponja" className="logo__container-logo" />
          <img src={MobileLogo} alt="saponja mobilni" className="logo__container-mobile-logo" />
        </div>
      </Link>
      <div className="title__container">
        <Link className="section-link" to="/">Naslovnica</Link>
        <Link className="section-link" to="/animal/filter">Udomi</Link>
        <Link className="section-link" to="/shelter/filter">Azili</Link>
        <Link className="section-link" to="/">Novosti</Link>
        <Link className="section-link" to="/">Doniraj</Link>
        <Link className="section-link" to="/">Prijavi se</Link>
        <img src={Hamburger} alt="hamburger" className="title__container-hamburger" />
      </div>
    </NavBarWrapper>
  );
};

export default NavigationBar;
