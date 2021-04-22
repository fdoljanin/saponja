import React from 'react';
import ReactDOM from 'react-dom';
import configureAxios from 'services/axiosConfiguration';
import App from './App';

configureAxios();

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root"));
