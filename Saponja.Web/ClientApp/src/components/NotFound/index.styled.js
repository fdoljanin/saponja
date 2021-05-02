import styled from "styled-components";

export const NotFoundWrapper = styled.main`
width: 100vw;
height: 100vh;
display: flex;
justify-content: center;
align-items: center;
position: relative;

.not-found-dog {
  position: absolute;
  z-index: 2;
  transform: translateX(-50px);
}
.error-number {
  font-family: PoppinsMedium;
  font-style: normal;
  font-weight: bold;
  font-size: 176px;
  line-height: 264px;
  color: #2B343A;
  position: absolute;
  z-index: 1;
  transform: translate(-50px, -200px);
}
.error-message {
  position: absolute;
  z-index: 1;
  transform: translate(-50px, 230px);
  font-family: Poppins;
  font-style: normal;
  font-weight: bold;
  font-size: 96px;
  line-height: 144px;
  color: #2B343A;
}
.tears-left,
.tears-right {
  position: absolute;
  z-index: 3;
  transform: translate(-140px, 100px);
}
.tears-left {
  animation: dropDownLeftTear 2s forwards infinite;
  animation-delay: 0.5s;
}
.tears-right {
  transform: translate(30px, 40px);
  animation: dropDownRightTear 2s forwards infinite;
}
@keyframes dropDownLeftTear {
  0% {
    transform: translate(-140px, 100px);
  }
  80% {
    transform: translate(-140px, 130px);
  }
  100% {
    opacity: 0;
  }
}
@keyframes dropDownRightTear {
  0% {
    transform: translate(30px, 40px);
  }
  80% {
    transform: translate(30px, 70px);
  }
  100% {
    opacity: 0;
  }
}
@media screen and (max-width: 788px) {
  .not-found-dog {
    transform: scale(0.6);
  }
  .error-number {
    font-size: 136px;
    line-height: 168px;
    transform: translate(-10px, -150px);
  }
  .error-message {
    font-size: 64px;
    line-height: 80px;
    transform: translate(-10px, 190px);
  }
  .tears-right,
  .tears-left {
    display: none;
  }
}
`;