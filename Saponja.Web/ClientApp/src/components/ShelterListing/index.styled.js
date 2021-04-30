import styled from "styled-components";

export const ShelterCardWrapper = styled.article`
height: 328px;
width: 976px;
padding: 40px 136px;
border-radius: 24px;
margin-bottom: 24px;

background: #FDFFFD;

display: flex;
flex-direction: column;
justify-content: space-between;
position: relative;

.card-image--paw {
  height: 56px;
  width: 56px;
  position: absolute;
  top: 40px;
  left: 40px;
}

.card-title {
  font-family: Poppins;
  font-weight: 500;
  font-size: 39.06px;
  line-height: 48px;

  margin-bottom: 8px;

  color: #2B343A;
}

a {
  font-family: Poppins;
  font-weight: 600;
  font-size: 16px;
  line-height: 24px;

  height: max-content;
  color: #91B2CB;
  text-decoration: underline;
}

.card-info > p {
  font-family: Poppins;
  font-weight: 400;
  font-size: 16px;
  line-height: 24px;

  color: #2B343A;
}

.card-info {
  height: 52px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.card-contact {
  display: flex;
  justify-content: space-between;
}

.card-continue {
  align-self: flex-end;
}
`;

export const ShelterListWrapper = styled.section`
  display: flex;
  flex-direction: column;
  margin: auto;
  width: max-content;
`;