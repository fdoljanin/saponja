import React from "react";
import Paw from "./Assets/šapica.svg";
import NavigationBar from "../NavigationBar";
import LoginBackground from "./Assets/prijavi se pozadina.svg";
import Doggies from "./Assets/pasici prijava.png";
import "./login.css";

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
        <img src={Doggies} alt="doggies" className="login-dogs" />
        <div className="login-container">
          <div className="login-container-title">
            <p>Prijava</p>
            <img src={Paw} alt="šapa" />
          </div>
          <input placeholder="E-mail" />
          <input placeholder="Lozinka" />
          <div className="login-container-button">
            <button>Prijavi se</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Login;
