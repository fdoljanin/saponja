import React from "react";

import "./style.css";

const FosteringInfo = ({onShowForm}) => {
  return (
    <div className="animal__details-foster-info">
      <h6>Želiš me udomiti?</h6>
      <p>Sve možeš odraditi iz udobnosti svoga doma!</p>
      <p>
        Sve što trebaš učiniti je javiti se da si zainteresiran, ispuniti
        podatke i kada je sve dogovoreno, bit ćeš obavješten putem maila s
        daljnjim uputama i potrebnom dokumentacijom.
      </p>
      <p>
        Potrebnu dokumentaciju možeš i odmah preuzeti <span>ovdje.</span>
      </p>
      <button onClick={onShowForm}>Raspitaj se</button>
      <p className="animal__details-foster-info-bottom-text">
        Možeš i direktno kontaktirati moj azil, kontakt podacima možeš
        prisutpiti na njihovom profilu.
      </p>
    </div>
  );
};

export default FosteringInfo;
