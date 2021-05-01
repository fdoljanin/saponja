import axios from "axios";
import AddShelter from "components/AddShelter";
import AnimalDetails from "components/AnimalDetails";
import MultiplePicker from "components/Filters/MultiplePicker";
import RadioPicker from "components/Filters/RadioPicker";
import ShelterFilter from "components/Filters/ShelterFilter";
import SortPicker from "components/Filters/SortPicker";
import StringInputPicker from "components/Filters/StringInputPicker";
import PagePicker from "components/PagePicker";
import ParamTest from "components/ParamsTest";
import ShelterListing from "components/ShelterListing";
import ShelterList from "components/ShelterListing/ShelterList";
import React, { useEffect, useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import UserProvider from "services/providers/user";
import { setTextRange } from "typescript";
import Login from './components/Login';
import { getArrayFromBase32, getBase32FromArray, getSequenceFromArray } from "utils/arrayHelpers";
import { ANIMAL_ENUMS } from "consts/modelEnums";
import { filterType } from "consts/enums";
import AnimalFilter from "components/Filters/AnimalFilter";
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