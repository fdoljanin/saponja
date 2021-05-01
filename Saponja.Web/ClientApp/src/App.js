
import React, { useEffect, useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import AnimalListing from "components/AnimalListing";
import MainScreen from "components/LandingPage/MainScreen";
import Login from "components/Login";
import AddPost from "components/AddPost";
import UserProvider from "services/providers/user";
import AnimalDetails from "components/AnimalDetails/MainScreen";

const App = () => {

  return <BrowserRouter>
    <UserProvider>
      <Route exact path="/animal/filter/:specie?/:gender?/:age?/:location?/:sort?/:page?">
        <AnimalListing />
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
  </BrowserRouter>

  /*(
    <BrowserRouter>
      <UserProvider>
        <Route path="/login">
          <Login />
        </Route>
        <Route exact path="/shelters/add">
          <AddShelter />
        </Route>
      </UserProvider>
    </BrowserRouter>
  )*/
}

export default App;