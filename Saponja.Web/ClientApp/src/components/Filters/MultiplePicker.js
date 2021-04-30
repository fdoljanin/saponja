import React, { useEffect, useState } from "react";
import { PickerWrapper, CheckOption, NormalText } from "./index.styled";

const MultiplePicker = ({ options, values, setValues }) => {
  const allSelected = options.length === values.length;

  const toggleCheck = (i) => {
    setValues(prev => {
      return !prev.some(v => v === i)
        ?
        [...prev, i]
        :
        prev.filter(v => v !== i);
    })
  }

  const selectAll = () => {
    setValues(allSelected ? [] : Array(options.length).fill(0).map((e, i) => i));
  }

  return (
    <PickerWrapper className="filter-picker">
      {
        options.map((value, i) =>
          <CheckOption className="picker-option" key={i} ischecked={values.some(v => v == i)}>
            <div className="picker-checkbox"
              onClick={() => toggleCheck(i)} />
            <NormalText className="picker-value">{value}</NormalText>
          </CheckOption>
        )
      }
      <CheckOption className="picker-option" ischecked={allSelected}>
        <div className="picker-checkbox"
          onClick={() => selectAll()} />
        <NormalText className="picker-value">Prikaži sve</NormalText>
      </CheckOption>
    </PickerWrapper>
  )
}

export default MultiplePicker;