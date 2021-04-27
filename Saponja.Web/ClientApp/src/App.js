import AnimalDetails from "components/AnimalDetails";
import React from "react";
import { BrowserRouter, Route } from "react-router-dom";
import UserProvider from "services/providers/user";
import Login from './components/Login';

const App = () => {
  return (
    <BrowserRouter>
      <UserProvider>
        <Route path="/login">
          <Login />
        </Route>
      </UserProvider>
    </BrowserRouter>
  )
}

export default App;