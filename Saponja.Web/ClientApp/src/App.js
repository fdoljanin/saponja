import AddShelter from "components/AddShelter";
import AnimalDetails from "components/AnimalDetails";
import ShelterList from "components/ShelterListing/ShelterList";
import React from "react";
import { BrowserRouter, Route } from "react-router-dom";
import UserProvider from "services/providers/user";
import Login from './components/Login';

const App = () => {
  return <BrowserRouter><ShelterList /></BrowserRouter>/*(
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