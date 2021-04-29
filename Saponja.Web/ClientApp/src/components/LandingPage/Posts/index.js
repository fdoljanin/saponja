import React from "react";
import "./style.css";
import IconRight from "../Assets/icons/icon angle right.svg";
import Chocolate from "../Assets/cokolada.jpeg";

const Posts = () => {
  return (
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
          <div className="posts__container-button">
            <p className="posts__container-button-text">
              Saznaj više{" "}
              <svg
                id="Filled"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                width="16px" height="16px"
              >
                <title>168 arrow right</title>
                <path fill="#91b2cb" d="M6.293,22.293a1,1,0,1,0,1.414,1.414l8.172-8.172a5.005,5.005,0,0,0,0-7.07L7.707.293A1,1,0,0,0,6.293,1.707l8.172,8.172a3,3,0,0,1,0,4.242Z" />
              </svg>
            </p>
          </div>
        </div>
      </div>
    </article>
  );
};

export default Posts;
