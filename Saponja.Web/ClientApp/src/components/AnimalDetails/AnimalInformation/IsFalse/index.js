import React from "react";
import './style.css';

const IsFalse = () => {
  return (
    <div className="cross-box">
      <svg
        id="Filled"
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 24 24"
        className="cross"
      >
        <title>180 cross</title>
        <path
          fill="#fdfffd"
          d="M13.414,12,23.707,1.707A1,1,0,0,0,22.293.293L12,10.586,1.707.293A1,1,0,0,0,.293,1.707L10.586,12,.293,22.293a1,1,0,0,0,0,1.414h0a1,1,0,0,0,1.414,0L12,13.414,22.293,23.707a1,1,0,0,0,1.414,0h0a1,1,0,0,0,0-1.414Z"
          stroke="#fdfffd"
          strokeWidth="3px"
        />
      </svg>
    </div>
  );
};

export default IsFalse;
