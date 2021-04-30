import styled from "styled-components";
import pawIcon from "assets/svgs/paw.svg";

export const PageNumber = styled.div`
  width: 40px;
  height: 40px;

  font-family: Poppins;
  font-weight: 500;
  font-size: 25px;
  line-height: 40px;
  text-align: center;

  color: ${({ isCurrent }) => isCurrent ? "2B343A" : "#2b343a9a"};
  text-decoration: ${props => !props.isCurrent && props.isClickable ? "underline" : "none"};
  background-image: url(${({ isCurrent }) => isCurrent ? pawIcon : ""});
  background-size: 36px 36px;
  background-repeat: no-repeat;
  background-position: center;
`;
export const PickerWrapper = styled.div`
  display: flex;

  .picker-arrow {
    align-self: center;
    height: 24px;
    width: 24px;
    margin: 0 8px;
  }
`;