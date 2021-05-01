import React, { useState } from "react";
import { useUser } from "services/providers/user/hooks";
import { Redirect } from "react-router";
import axios from "axios";
import { history } from "utils/BrowserHistoryWrapper";

import Paw from "../../assets/icons/šapica.svg";
import LoginBackground from "../../assets/login_assets/prijavi se pozadina.svg";
import LoginBackgroundMobile from '../../assets/login_assets/puppy geng pozadina.svg';
import Doggies from "../../assets/login_assets/pasici prijava.png";

import NavigationBar from "../NavigationBar";
import "./style.css";

const initialState = {
  credentials: {
    email: "",
    password: ""
  }
}

const Login = () => {
  const [credentialsForm, setCredentialsForm] = useState(initialState.credentials);

  const user = useUser();
  if (user) {
    return <Redirect to="/home" />
  }

  const handleChange = ({ target: { name, value } }) => {
    setCredentialsForm((prevState) => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post("api/Account/Login", credentialsForm)
      .then(({ data }) => {
        localStorage.setItem("token", data);
        console.log(data);
        history.push("/home");
      })
      .catch((e) => {
        console.log(e); //implement error message
        alert("Err");
      });
  }

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
        <form className="login-container" onSubmit={handleSubmit}>
          <div className="login-container-title">
            <p>Prijava</p>
            <img src={Paw} alt="šapa" />
          </div>
          <input placeholder="E-mail" onChange={handleChange} name="email" />
          <input placeholder="Lozinka" onChange={handleChange} name="password" type="password" />
          <div className="login-container-button">
            <button type="submit">Prijavi se</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;