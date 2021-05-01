import React, { useState } from "react";
import { parseJwt } from "utils/jwtParser";
import { history } from "utils/BrowserHistoryWrapper";
import axios from "axios";
import { newToken } from "services/axiosConfiguration";

const token = localStorage.getItem("token");
const tokenParsed = parseJwt(token);
const initialState = {
  role: tokenParsed?.role,
  userId: tokenParsed?.userId,
};

export const UserContext = React.createContext({
  state: { ...initialState },
  logOut: () => { },
});

const UserProvider = ({ children }) => {
  const [role, setRole] = useState(initialState.role);
  const [userId, setUserId] = useState(initialState.userId);

  const logOut = () => {
    localStorage.removeItem("token");
    setRole(null);
    setUserId(null);
    history.push("/login");
  };

  const refreshToken = () => newToken(token)
    .then(({ data }) => localStorage.setItem("token", data))
    .catch(logOut);

  if (token) {
    refreshToken();
  }

  const value = {
    state: { role, userId },
    logOut,
  };

  return <UserContext.Provider value={value}>{children}</UserContext.Provider>;
};

export default UserProvider;