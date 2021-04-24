import React from "react";
import Logo from "./Assets/logo.svg";
import Corgi from "./Assets/header.png";
import Heart from "./Assets/srce.svg";
import BulldogBackground from "./Assets/pozadina za bulldoga.svg";
import Bulldog from "./Assets/bulldog bez pozadine.png";
import IconRight from "./Assets/icons/icon angle right.svg";
import Chocolate from "./Assets/cokolada.jpeg";
import AnimalsBackground from "./Assets/pozadina za grupu životinja.svg";
import Animals from "./Assets/grupa životinja bez pozadine.png";
import "./landingPage.css";

const LandingPage = () => {
  return (
    <body>
      <nav>
        <div className="logo__container">
          <img src={Logo} alt="saponja" />
        </div>
        <div className="title__container">
          <button>Naslovnica</button>
          <button>Udomi</button>
          <button>Azili</button>
          <button>Novosti</button>
          <button>Doniraj</button>
          <button>Prijavi se</button>
        </div>
      </nav>
      <header>
        <div className="header__banner">
          <img src={Corgi} alt="Corgi" className="header__banner-dog" />
          <img src={Heart} alt="heart" className="header__banner-heart" />
        </div>
      </header>
      <section className="info__section">
        <div className="info__section-container">
          <div>
            <h6 className="info__section-container-title">Zašto udomiti?</h6>
            <p className="info__section-container-text">
              Preopterećena skloništa diljem svijeta svake godine prihvate
              milijune zalutalih, zlostavljanih i izgubljenih životinja.
              Udomljavanjem životinje pravite mjesta drugima. Ne samo da dajete
              više životinja drugu priliku za sreću, već i omogućavate
              skloništima bolju skrb za ostale životinje o kojima se brinu.
            </p>
          </div>
        </div>
        <img
          src={BulldogBackground}
          alt="pozadina za bulldoga"
          className="info__section-bulldog-background"
        />
        <img src={Bulldog} alt="bulldog" className="info__section-bulldog" />
      </section>
      <article className="posts">
        <div className="posts__heading-container">
          <p className="posts__heading-container-title">Novosti</p>
          <img
            src={IconRight}
            alt="strelica"
            className="posts__heading-container-arrow"
          />
        </div>
        <div className="posts__container">
          <img src={Chocolate} alt="coco" className="posts__container-image" />
          <div>
            <p className="posts__container-date">24. Travnja 2021.</p>
            <p className="posts__container-title">
              Svakodnevne namirnice koje su štetne za naše ljubimce
            </p>
            <p className="posts__container-text">
              Neke namirnice koje se smatraju dobrima za ljude mogu biti vrlo
              opasne za kućne ljubimce. Popis u nastavku ističe neke od
              najčešćih...
            </p>
            <button className="posts__container-button">
              <p className="posts__container-button-text">
                Saznaj više{" "}
                <img
                  src={IconRight}
                  alt="strelica"
                  className="posts__container-button-arrow"
                />
              </p>
            </button>
          </div>
        </div>
      </article>
      <section className="bottom__section">
          <p className="bottom__section-text">
            Nama ste vi čitav svijet. Pružite nam dom, a mi ćemo vratiti
            bezuvjetnu ljubav.
          </p>
          <img
            src={AnimalsBackground}
            alt="pozadina za životinje"
            className="bottom__section-animals-background"
          />
          <img
            src={Animals}
            alt="grupa životinja"
            className="bottom__section-animals"
          />
      </section>
      <footer>
          <p className="footer__text">© 2021. Sva prava pridržana.</p>
      </footer>
    </body>
  );
};

export default LandingPage;
