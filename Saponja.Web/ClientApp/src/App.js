import TestingUnit from "components/TestingUnit";
import React from "react";
import { BrowserRouter } from "react-router-dom";
import UserProvider from "services/providers/user";

const App = () => {
  return (
    <BrowserRouter>
      <UserProvider>
        <TestingUnit />
      </UserProvider>
    </BrowserRouter>
  )
}

export default App;