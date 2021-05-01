import React from "react";
import { SortPickerWrapper, SortOption } from "./index.styled";
import arrowIcon from "assets/svgs/arrowDrop.svg"

const SortPicker = ({ options, value, setValue }) => {
  return (
    <SortPickerWrapper className="sort__picker">
      <p className="sort-title">Poredaj po</p>
      <img src={arrowIcon} className="sort-arrow" alt="Dropdown icon"/>
      <div className="sort-options">
        {options.map((option, i) =>
          <SortOption onClick={() => setValue(i)} isSelected={i === value} key={i}>
            {option}
          </SortOption>
        )}
      </div>
    </SortPickerWrapper>
  )
}

export default SortPicker;