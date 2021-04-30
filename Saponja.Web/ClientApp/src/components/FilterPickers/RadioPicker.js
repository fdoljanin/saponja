import React from "react";
import {NormalText, PickerWrapper, RadioOption} from "./index.styled";

const RadioPicker = ({ options, value, setValue }) => {
  return (
    <PickerWrapper>
      {options.map((option, i) =>
        <RadioOption className="picker-option" key={i} isselected={value === i}>
          <div className="picker-circle"
            onClick={() => setValue(i)} />
          <NormalText className="picker-value">{option}</NormalText>
        </RadioOption>
      )}
    </PickerWrapper>
  )
}

export default RadioPicker;