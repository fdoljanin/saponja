
import React, { useEffect, useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import AnimalListing from "components/AnimalListing";

const App = () => {

  return <BrowserRouter>
      <Route exact path="/animal/filter/:specie?/:gender?/:age?/:location?/:sort?/:page?">
        <AnimalListing />
      </Route>
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