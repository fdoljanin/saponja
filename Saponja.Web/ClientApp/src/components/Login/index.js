import React from "react";

import Paw from "../../assets/icons/šapica.svg";
import LoginBackground from "../../assets/login_assets/prijavi se pozadina.svg";
import LoginBackgroundMobile from '../../assets/login_assets/puppy geng pozadina.svg';
import Doggies from "../../assets/login_assets/pasici prijava.png";

import NavigationBar from "../NavigationBar";
import "./style.css";

const Login = () => {
  return (
    <div>
      <NavigationBar />
      <div className="login">
        <img
          src={LoginBackground}
          alt="background"
          className="login-background"
        />
        <img src={LoginBackgroundMobile}
          alt="background mobile"
          className="login-background-mobile"
        />
        <img src={Doggies} alt="doggies" className="login-dogs" />
        <form className="login-container">
          <div className="login-container-title">
            <p>Prijava</p>
            <img src={Paw} alt="šapa" />
          </div>
          <input placeholder="E-mail" />
          <input placeholder="Lozinka" />
          <div className="login-container-button">
            <button>Prijavi se</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;
