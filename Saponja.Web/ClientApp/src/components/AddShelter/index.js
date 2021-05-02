import React from "react";
import axios from "axios";
import { useState } from "react";

const initialState = {
  credentials: {
    email: "",
    password: ""
  },
  info: {
    name: "",
    city: "",
    address: "",
    description: "",
    websiteUrl: "",
    contactPhone: "",
    contactEmail: "",
    oib: "",
    iban: ""
  },
  geolocation: {
    longitude: "",
    latitude: ""
  }
}

const AddShelter = () => {
  const [credentials, setCredentials] = useState(initialState.credentials);
  const [info, setInfo] = useState(initialState.info);
  const [geolocation, setGeolocation] = useState(initialState.geolocation);
  const [documentation, setDocumentation] = useState();

  if (user.role !== userRole.ADMIN)
  return <Redirect to="/" />;

  const handleChange = (setter) => ({ target: { name, value } }) => {
    setter(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const shelter = {credentials, info: {...info, geolocation}};
    axios.post("api/Admin/RegisterShelter", shelter)
    .then(({data: shelterId}) => {
      const formData = new FormData();
      formData.append("DocumentationFile", documentation);

      axios.post(`api/Admin/AddShelterDocumentation?shelterId=${shelterId}`, formData);
    })
    .catch(err => console.log(err));
  }

  return (
    <form onSubmit={handleSubmit}>
      <input name="email" placeholder="email" onChange={handleChange(setCredentials)}/>
      <input name="password" placeholder="password" type="password" onChange={handleChange(setCredentials)}/>
      <input name="name" placeholder="name" onChange={handleChange(setInfo)} />
      <input name="city" placeholder="city" onChange={handleChange(setInfo)} />
      <input name="address" placeholder="address" onChange={handleChange(setInfo)} />
      <input name="description" placeholder="description" onChange={handleChange(setInfo)} />
      <input name="websiteUrl" placeholder="websiteUrl" onChange={handleChange(setInfo)} />
      <input name="contactPhone" placeholder="contactPhone" onChange={handleChange(setInfo)} />
      <input name="contactEmail" placeholder="contactEmail" onChange={handleChange(setInfo)} />
      <input name="oib" placeholder="oib" onChange={handleChange(setInfo)} />
      <input name="iban" placeholder="iban" onChange={handleChange(setInfo)} />
      <input name="longitude" placeholder="longitude" onChange={handleChange(setGeolocation)} />
      <input name="latitude" placeholder="latitude" onChange={handleChange(setGeolocation)} />
      <input name="documentation" type="file" onChange={e =>setDocumentation(e.target.files[0])} />
      <input type="submit"/>
    </form>
  )
}

export default AddShelter;