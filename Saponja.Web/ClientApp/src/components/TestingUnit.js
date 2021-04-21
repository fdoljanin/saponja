import React from "react";
import { useEffect } from "react";
import axios from "axios";

const TestingUnit = () => {
  useEffect(() => {
      const shelter = {
        credentials: {
          email: "pokusajN",
          password: "pass!!!22431"
        },
        info: {
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
        },
        geolocation: {
          longitude: 22.111,
          latitude: 70.58
        }
      }

      axios.post("api/Admin/RegisterShelter", shelter).then(resp => console.log(resp));
    }, [])


  return <h2> test! </h2>
}

export default TestingUnit;