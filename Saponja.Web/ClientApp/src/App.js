import AddShelter from "components/AddShelter";
import AnimalDetails from "components/AnimalDetails";
import PagePicker from "components/PagePicker";
import ShelterList from "components/ShelterListing/ShelterList";
import React, { useState } from "react";
import { BrowserRouter, Route } from "react-router-dom";
import UserProvider from "services/providers/user";
import { setTextRange } from "typescript";
import Login from './components/Login';

const App = () => {
  const [x, setX] = useState(1);
  const [y, setY] = useState(5);

  return <BrowserRouter>
    <input onChange={e => setX(e.target.value)} />
    <input onChange={e => setY(e.target.value)} />
    <PagePicker currentPage={x} pageCount={y} />
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