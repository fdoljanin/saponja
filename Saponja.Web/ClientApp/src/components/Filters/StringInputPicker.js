import React from "react";
import {NormalText, StringInputWrapper} from "./index.styled";

const StringInputPicker = ({ value, setValue, placeholder, isNumber }) => {
  return (
    <StringInputWrapper className="filter-picker">
      <NormalText>
        <input value={value} className="string-input" type={isNumber ? "number" : "text"}
          onChange={e => setValue(e.target.value)}
          placeholder={placeholder} />
      </NormalText>
    </StringInputWrapper>
  )
}

export default StringInputPicker;