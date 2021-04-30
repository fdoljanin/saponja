import React from "react";
import { useParams } from "react-router-dom";

const ParamTest = () => {
  const params = useParams();
  console.log(params);
  return <h1>okk</h1>
}

export default ParamTest;