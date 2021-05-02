import AnimalDetails from './components/AnimalDetails/MainScreen';
import React from "react";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import AnimalListing from "components/AnimalListing";
import MainScreen from "components/LandingPage/MainScreen";
import Login from "components/Login";
import AddPost from "components/AddPost";
import UserProvider from "services/providers/user";
import NavigationBar from "components/NavigationBar";
import Footer from "components/Footer";
import ShelterListing from "components/ShelterListing";
import NotFound from 'components/NotFound';

const App = () => {
  return <BrowserRouter>
    <UserProvider>
      <NavigationBar />
      <div className="content">
        <Switch>
          <Route exact path="/animal/filter/:specie?/:gender?/:age?/:location?/:sort?/:page?">
            <AnimalListing />
          </Route>
          <Route exact path="/shelter/filter/:location?/:distance?/:name?/:sort?/:page?">
            <ShelterListing />
          </Route>
          <Route exact path="/post/add">
            <AddPost />
          </Route>
          <Route exact path="/login">
            <Login />
          </Route>
          <Route exact path="/">
            <MainScreen />
          </Route>
          <Route exact path="/animal/:id">
            <AnimalDetails />
          </Route>
          <Route exact path="/404">
            <NotFound /> 
          </Route>
          <Redirect to="/404" />
        </Switch>
      </div>
    </UserProvider>
    <Footer />
  </BrowserRouter>
}

export default App;