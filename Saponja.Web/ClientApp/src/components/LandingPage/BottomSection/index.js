import React from "react";
import AnimalsBackground from "../../../assets/landingPage_assets/pozadina za grupu životinja.svg";
import Animals from "../../../assets/landingPage_assets/grupa životinja bez pozadine.png";
import "./style.css";

const BottomSection = () => {
  return (
    <section className="bottom__section">
      <p className="bottom__section-text">
        Nama ste vi čitav svijet. Pružite nam dom, a mi ćemo vratiti bezuvjetnu
        ljubav.
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
  );
};

export default BottomSection;
