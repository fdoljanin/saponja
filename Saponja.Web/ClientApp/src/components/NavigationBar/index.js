import React from "react";
import { Link, useLocation } from 'react-router-dom';

import Logo from '../../assets/navigationBar_assets/logo.svg';
import MobileLogo from "../../assets/navigationBar_assets/logo mobile.svg";
import Hamburger from '../../assets/icons/icon menu burger.svg';
import { NavBarWrapper } from "./index.styled.js";
import { useLogoutUser} from "services/providers/user/hooks";

const reversedPaths = ["login", "donate", "news", "shelter", "animal", ""];

const NavigationBar = () => {
  const { pathname: currentPath } = useLocation();
  const currentSectionIndex = reversedPaths.length - reversedPaths.findIndex(p => currentPath.includes(p));
  const [user, logoutUser] = useLogoutUser();

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
        {!user
          ? <Link className="section-link" to="/login">Prijavi se</Link>
          : <p className="section-link" onClick={() => logoutUser()}>Odjavi se</p>}
        <img src={Hamburger} alt="hamburger" className="title__container-hamburger" />
      </div>
    </NavBarWrapper>
  );
};

export default NavigationBar;
