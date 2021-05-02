import styled from "styled-components";
import checkedIcon from "assets/svgs/checked.svg";
import ucheckedIcon from "assets/svgs/unchecked.svg";
import selectedIcon from "assets/svgs/selected.svg";
import unselectedIcon from "assets/svgs/unselected.svg";

export const PickerWrapper = styled.div`
display: flex;
flex-direction: column;

min-width: 270px;
width: max-content;
border-radius: 24px;
padding: 40px 40px 40px 40px;

background: #FDFFFD;

.picker-option:last-child {
  margin-bottom: 0;
}
`;

export const CheckOption = styled.div`
display: flex;
margin-bottom: 16px;

.picker-checkbox {
  width: 24px;
  height: 24px;
  background-image: url(${props => props.ischecked ? checkedIcon : ucheckedIcon});
  transition: background-image 0.2s ease-in-out;
}

.picker-value {
  margin-left: 16px;
  align-self: center;
  opacity: 0.6;
}
`;

export const StringInputWrapper = styled.div`
background: #FDFFFD;
border-radius: 24px;
padding: 16px 40px 24px 40px;
width: max-content;

.string-input {
  all: inherit;

  border: none;
  border-bottom: 2px solid #DDD;
  width: 24ch;

  opacity: 0.6;
}
`;

export const NormalText = styled.p`
  font-family: Poppins;
  font-weight: normal;
  font-size: 16px;
  line-height: 24px;
  color: #2B343A;
`;

export const RadioOption = styled.div`
display: flex;
margin-bottom: 16px;

.picker-circle {
  width: 24px;
  height: 24px;
  background-image: url(${props => props.isselected ? selectedIcon : unselectedIcon});
  transition: background-image 0.2s ease-in-out;
}

.picker-value {
  margin-left: 16px;
  align-self: center;
  opacity: 0.6;
}

`;

export const FilterWrapper = styled.div`
background: #FDFFFD;
display: flex;
width: max-content;
border-radius: 50px;
z-index: 1;

.filter-option:first-child{
  padding-left: 40px;
}

.filter-option:last-child {
  background-color: #91B2CB;
  color: white;
  align-items: center;
  justify-content: center;
  font-weight: 500;
}
`;

export const FilterOption = styled.div`
width: 160px;
height: 80px;
border-radius: 50px;
position: relative;
cursor: pointer;

display: flex;
flex-direction: column;
padding: 16px 24px;

font-family: Poppins;
font-weight: normal;
color: #2B343A;
transition: all 0.2s ease-in-out;

.filter-name {
  font-size: 16px;
  line-height: 24px;
  margin-bottom: 8px;
}

.filter-explain {
  opacity: 0.5;
  font-size: 14px;
  line-height: 16px;
}

.filter-picker {
  opacity: 0;
  pointer-events: none;
  position: absolute;
  top: 96px;
  left: 0;
}

.filter-close {
  position: absolute;
  top: 16px;
  right: 16px;
  height: 24px;
  width: 24px;
  opacity: 0;
  pointer-events: none;
}

&:hover {
  background-color: #D0DCE4;
}

${({ focused }) => focused && `
  box-shadow: 0px 0px 32px rgba(0, 0, 0, 0.1);

  .filter-picker, .filter-close{
    opacity:1;
    pointer-events: auto;
  }

    background-color: #FDFFFD !important;
    `};

`;

export const SortPickerWrapper = styled.div`
align-self: center;
font-family: Poppins;
width: 178px;
padding: 20px 24px 16px 24px;
background: #FDFFFD;
border-top-right-radius: 24px;
border-top-left-radius: 24px;
display: flex;
justify-content: space-between;
position: relative;

.sort-title {
  font-size: 16px;
  line-height: 24px;
  font-weight: 500;
  color: #91B2CB;
}

.sort-arrow {
  width: 16px;
  height: 16px;
  transition: transform 0.2s ease-in-out;
  align-self: center;
}

.sort-options {
  background: #FDFFFD;
  margin-top: 4px;
  width: 178px;
  padding-left: 24px;

  opacity: 0;
  transform: all 0.2s ease-in-out;
  pointer-events: none;
  position: absolute;
  top: 56px;
  left: 0;
  border-bottom-right-radius: 24px;
  border-bottom-left-radius: 24px;
}

&:hover > .sort-arrow {
  transform: rotate(180deg);
}

&:hover > .sort-options {
  opacity: 1;
  pointer-events: auto;
}
`;

export const SortOption = styled.div`
  font-size: 16px;
  line-height: 24px;
  color: #2B343A;
  opacity: ${({ isSelected }) => isSelected ? 1 : 0.4};
  margin-bottom: 16px;
`;