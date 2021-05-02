import React, { useState } from "react";
import { Link, useLocation } from 'react-router-dom';
import Logo from '../../assets/navigationBar_assets/logo.svg';
import MobileLogo from "../../assets/navigationBar_assets/logo mobile.svg";
import Hamburger from '../../assets/icons/icon menu burger.svg';
import { NavBarWrapper } from "./index.styled.js";
import { useLogoutUser } from "services/providers/user/hooks";
const reversedPaths = ["login", "donate", "news", "shelter", "animal", ""];
const NavigationBar = () => {
  const { pathname: currentPath } = useLocation();
  const currentSectionIndex = reversedPaths.length - reversedPaths.findIndex(p => currentPath.includes(p));
  const [user, logoutUser] = useLogoutUser();
  const [showModule, setShowModule] = useState(false);

  return (
    <NavBarWrapper currentSection={currentSectionIndex} showModule={showModule}>
      <div className="logo__container">
        <Link to="/" className="logo__link">
          <img src={Logo} alt="saponja" className="logo__container-logo" />
          <img src={MobileLogo} alt="saponja mobilni" className="logo__container-mobile-logo" />
        </Link>
        <img src={Hamburger} alt="hamburger"
          className="logo__container-hamburger" onClick={() => setShowModule(prev => !prev)} />
      </div>
      <div className="title__container">
        <Link className="section-link" onClick={() => setShowModule(false)} to="/">Naslovnica</Link>
        <Link className="section-link" onClick={() => setShowModule(false)} to="/animal/filter">Udomi</Link>
        <Link className="section-link" onClick={() => setShowModule(false)} to="/shelter/filter">Azili</Link>
        <Link className="section-link" onClick={() => setShowModule(false)} to="/">Novosti</Link>
        <Link className="section-link" onClick={() => setShowModule(false)} to="/">Doniraj</Link>
        {!user
          ? <Link className="section-link" to="/login">Prijavi se</Link>
          : <p className="section-link" onClick={() => logoutUser()}>Odjavi se</p>}
      </div>
    </NavBarWrapper>
  );
};
export default NavigationBar;