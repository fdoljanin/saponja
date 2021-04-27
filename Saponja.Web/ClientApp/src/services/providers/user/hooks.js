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