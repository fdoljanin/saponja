
import React, { useEffect, useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import AnimalListing from "components/AnimalListing";
import MainScreen from "components/LandingPage/MainScreen";
import Login from "components/Login";
import AddPost from "components/AddPost";
import UserProvider from "services/providers/user";
import AnimalDetails from "components/AnimalDetails/MainScreen";
import NavigationBar from "components/NavigationBar";
import Footer from "components/Footer";
import ShelterListing from "components/ShelterListing";

const App = () => {
  return <BrowserRouter>
  <NavigationBar />
    <UserProvider>
      <Route exact path="/animal/filter/:specie?/:gender?/:age?/:location?/:sort?/:page?">
        <AnimalListing />
      </Route>
      <Route exact path="/shelter/filter/:location?/:distance?/:name?/:sort?/:page?">
        <ShelterListing />
      </Route>
      <Route exact path="/post/add">
        <AddPost />
      </Route>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/">
        <MainScreen />
      </Route>
      <Route exact path="/animal/:id">
        <AnimalDetails />
      </Route>
    </UserProvider>
    <Footer />
  </BrowserRouter>
}

export default App;