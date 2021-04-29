import React from "react";
import "./style.css";
import BulldogBackground from "../Assets/pozadina za bulldoga.svg";
import Bulldog from "../Assets/bulldog bez pozadine.png";

const Banner = () => {
  return (
    <section className="banner">
      <div className="banner-container">
        <div>
          <h6 className="banner-container-title">Zašto udomiti?</h6>
          <p className="banner-container-text">
            Preopterećena skloništa diljem svijeta svake godine prihvate
            milijune zalutalih, zlostavljanih i izgubljenih životinja.
            Udomljavanjem životinje pravite mjesta drugima. Ne samo da dajete
            više životinja drugu priliku za sreću, već i omogućavate skloništima
            bolju skrb za ostale životinje o kojima se brinu.
          </p>
        </div>
        <div>
          <img
            src={BulldogBackground}
            alt="pozadina za bulldoga"
            className="banner-bulldog-background"
          />
          <img src={Bulldog} alt="bulldog" className="banner-bulldog" />
        </div>
      </div>
    </section>
  );
};

export default Banner;
