import styled from "styled-components";

export const NavBarWrapper = styled.nav`
position: sticky;
top: 0;

z-index: 3;
background: #FDFFFD;
display: flex;
justify-content: space-between;
align-items: center;
padding: 16px 152px;

.logo__container-logo {
  width: 164px;
  height: 56px;
}
.logo__container-mobile-logo {
  display: none;
}
.logo__container-hamburger {
  display: none;
  width: 24px;
  height: 24px;
}
.section-link {
  font-family: Poppins;
  font-style: normal;
  font-weight: 500;
  font-size: 16px;
  line-height: 40px;
  padding: 0;
  border: none;
  background-color: transparent;
  margin-right: 56px;
  cursor: pointer;
}
.section-link {
  display: inline-block;
  color: #2B343A;
}
.section-link:last-child {
  margin-right: 0;
}
.section-link::after {
  content: "";
  display: block;
  width: 0;
  height: 3px;
  margin-top: -8px;
  background: #91B2CB;
  transition: width 0.3s;
}
.section-link:hover::after {
  width: 100%;
}
.section-link:nth-child(${props => props.currentSection}) {
  color: #91B2CB;
  margin-right: 56px;
}
.section-link:nth-child(${props => props.currentSection}):after {
  transition: none !important;
  width: 100%;
}

@media only screen and (max-width: 1300px) {
  padding: 16px 88px;
  .logo__container-logo {
    display: none;
  }
  .logo__container-mobile-logo {
    display: block;
  }
}
@media only screen and (max-width: 1200px) {
  padding: 16px 56px;
  flex-direction: column;
  .logo__link {
    width: 100%;
  }
  .logo__container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
  }

  .title__container {
    height: calc(100vh - 88px);
    display: ${props => props.showModule ? "flex" : "none"};
    justify-content: center;
    align-items: center;
    flex-direction: column;
    z-index: 3;
    overflow: hidden;
  }
  .section-link:nth-child(${props => props.currentSection}) {
    margin-right: 0;
}
  .section-link {
    display: flex;
    flex-direction: column;
    margin: 0 0 16px 0;
  }
  .logo__container-hamburger {
    display: block;
  }
}
@media screen and (max-width: 441px) {
  padding: 16px 24px;
}`;