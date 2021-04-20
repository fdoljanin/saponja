import React from "react";
import { BrowserRouter } from "react-router-dom";
import UserProvider from "services/providers/user";

const App = () => {
  return (
    <BrowserRouter>
      <UserProvider>
      </UserProvider>
    </BrowserRouter>
  )
}

export default App;