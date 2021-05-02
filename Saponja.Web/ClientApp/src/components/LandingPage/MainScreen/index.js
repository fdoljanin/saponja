import React from "react";

import NavigationBar from '../../NavigationBar';
import Header from '../Header';
import Banner from '../Banner';
import Posts from '../Posts';
import BottomSection from '../BottomSection';
import Footer from '../../Footer';
import './style.css';

const MainScreen = () => {
  return (
    <div>
      <Header />
      <Banner />
      <Posts />
      <BottomSection />
    </div>
  );
};

export default MainScreen;
