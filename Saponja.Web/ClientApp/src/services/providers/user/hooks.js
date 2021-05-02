import { useContext } from "react";
import { UserContext } from "."

const useUserContext = () => {
  return useContext(UserContext);
}

export const useUser = () => {
  const {
    state: { role, userId },
  } = useUserContext();
  return role ? {role, id: userId} : undefined;
}

export const useLogoutUser = () => {
  const {
    state: { role, userId },
    logOut
  } = useUserContext();
  return role ? [{role, id: userId}, logOut] : [undefined, undefined];
}