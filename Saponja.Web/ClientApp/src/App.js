import AddShelter from "components/AddShelter";
import AnimalDetails from "components/AnimalDetails";
import MultiplePicker from "components/FilterPickers/MultiplePicker";
import RadioPicker from "components/FilterPickers/RadioPicker";
import StringInputPicker from "components/FilterPickers/StringInputPicker";
import PagePicker from "components/PagePicker";
import ShelterList from "components/ShelterListing/ShelterList";
import React, { useEffect, useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import UserProvider from "services/providers/user";
import { setTextRange } from "typescript";
import Login from './components/Login';

const App = () => {
  const [values, setValues] = useState("");
  const options = ["konj", "macka", "pas"];
  const [value, setValue] = useState(0);

  return <BrowserRouter>
  <RadioPicker value={value} setValue={setValue} options={options}/>
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