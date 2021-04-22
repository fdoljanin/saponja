import React, { useState } from "react";
import { useEffect } from "react";
import axios from "axios";

const TestingUnit = () => {
  const [documentation, setFile] = useState();

  const upload = async () => {
    //var shelter = new FormData();



    /*shelter.append("file", documentation);
    shelter.append("credentials", {
      email: "ss22",
      password: "pass!!!22431"
    });
    shelter.append("info", {
      name: "ALOUJ",
      city: "Split",
      address: "Krš 2020",
      description: `Azil na kršu
        krš azil
        žnj`,
      websiteUrl: "www.nemamostranicu.com",
      contactPhone: "000111000",
      contactEmail: "fifi@nemamomejl.com",
      iban: "10010100101001"
    });
    shelter.append("geolocation", {
      longitude: 22.111,
      latitude: 70.58
    });*/
  
    const shelter = {
      credentials: {
        email: "da bar uspi",
        password: "pass!!!22431"
      },
      info: {
        name: "ALOUJ",
        city: "Split",
        address: "Krš 2020",
        description: `Azil na kršu
        krš azil 3
        žnj`,
        websiteUrl: "www.nemamostranicu.com",
        contactPhone: "000111000",
        contactEmail: "fifi@nemamomejl.com",
        iban: "10010100101001"
      },
      geolocation: {
        longitude: 22.111,
        latitude: 70.58
      }
    }
    
    const formData = new FormData();
    formData.append("DocumentationFile", documentation);

    axios.post("api/Admin/RegisterShelter", shelter).then(({data}) => {
      formData.append("ShelterId", data);
      axios.post("api/Admin/AddShelterDocumentation", formData).then(r => console.log(r));
    })
    

  }
  return (
    <div>
      <input type="file" onChange={e => setFile(e.target.files[0])} />
      <button onClick={upload}>OK</button>
    </div>
  )
}

export default TestingUnit;