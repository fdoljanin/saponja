import React from "react";
import arrowLeftIcon from "assets/svgs/arrowLeft.svg";
import arrowRightIcon from "assets/svgs/arrowRight.svg";
import { PickerWrapper, PageNumber } from "./index.styled";



const PagePicker = ({ currentPage, pageCount, setPage }) => {
  const options = [
    1,
    2,
    currentPage > 2 && currentPage < pageCount - 1 ? currentPage : 3,
    currentPage == pageCount - 1 ? currentPage : "...",
    pageCount
  ];

  const neededNumberOfPages = [1, 2, 3, 5, 4];

  const handleClick = (value) => {
    if (value != currentPage && !isNaN(value)) {
      setPage(value);
    }
  };

  return (
    <PickerWrapper className="page__picker">
      {currentPage != 1 &&
        <img src={arrowLeftIcon} className="picker-arrow" alt="Turn page left"
          onClick={() => setPage(prev => prev - 1)} />}
      {options.map((value, i) =>
        neededNumberOfPages[i] <= pageCount &&
        <PageNumber key={i} isCurrent={currentPage == value}
          isClickable={!isNaN(value)} onClick={() => handleClick(value)}>
          {value}
        </PageNumber>

      )}
      {currentPage != pageCount &&
        <img src={arrowRightIcon} className="picker-arrow" alt="Turn page right"
          onClick={() => setPage(prev => prev + 1)} />}
    </PickerWrapper>
  )
}

export default PagePicker;