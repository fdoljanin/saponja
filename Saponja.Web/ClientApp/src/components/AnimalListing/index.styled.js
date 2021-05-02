import styled from "styled-components";
import cardBackgroundImage from "assets/svgs/cardBackground.svg";
import pawIcon from "assets/svgs/paw.svg";

export const AnimalListWrapper = styled.section`
  display: flex;
  flex-direction: column;
  margin: auto;
  width: max-content;
`;

export const AnimalListingWrapper = styled.main`
display: flex;
flex-direction: column;
align-items: center;

.listing-options {
  display: flex;
  width: 1078px;
  justify-content: space-between;
  margin-top: 40px;
  margin-bottom: 32px;
}

.page__picker {
  margin-bottom: 32px;
}
`;

export const AnimalCardWrapper = styled.article`
display: flex;
width: 730px;
padding: 56px;
border-radius: 24px;
justify-content: space-around;
background-color: #FDFFFD;
margin-bottom: 24px;

background-image: url(${cardBackgroundImage});
background-repeat: no-repeat;
background-size: 320px 396px;
background-position: 40px -40px;

.animal-photo {
  width: 272px;
  height: 200px;
  object-fit: cover;
  border-radius: 24px;
}

.animal-info {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 40%;
  margin: 0;

  background-image: url(${pawIcon});
  background-size: 40px;
  background-position: 100% 0;
  background-repeat: no-repeat;
}

.animal-name {
font-family: Poppins;
font-weight: 600;
font-size: 25px;
line-height: 32px;

color: #2B343A;
}

.animal-properties {
  margin: 24px 0;
}

.animal-properties p {
font-family: Poppins;
font-weight: normal;
font-size: 16px;
line-height: 24px;
margin-bottom: 8px;

color: #2B343A;
}

.animal-properties b {
  font-weight: 600
}

.animal-continue {
  width: 112px;
}
`;