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
  width: 30ch;

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