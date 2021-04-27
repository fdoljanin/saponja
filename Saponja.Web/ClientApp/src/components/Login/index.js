import React, { useState } from "react";
import Paw from './Assets/šapica.svg';
import NavigationBar from "../NavigationBar";
import LoginBackground from "./Assets/prijavi se pozadina.svg";
import Doggies from "./Assets/pasici prijava.png";
import "./login.css";
import { useUser } from "services/providers/user/hooks";
import { Redirect } from "react-router";
import axios from "axios";
import { history } from "utils/BrowserHistoryWrapper";

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
    .then(({data}) => {
      localStorage.setItem("token", data);
      console.log(data);
      history.push("/home");
    })
    .catch((e)=>{
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
        <img src={Doggies} alt="doggies" className="login-dogs" />
        <div className="login-container">
          <div className="login-container-title">
            <p>Prijava</p>
            <img src={Paw} alt="šapa" />
          </div>
          <form onSubmit={handleSubmit}>
            <input onChange={handleChange} name="email" placeholder="E-mail"/>
            <input onChange={handleChange} name="password" type="password" placeholder="Lozinka"/>
            <div className="login-container-button">
              <button type="submit">Prijavi se</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
};

export default Login;