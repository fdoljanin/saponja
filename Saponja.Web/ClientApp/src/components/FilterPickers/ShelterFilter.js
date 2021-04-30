import { useState } from "react";
import MultiplePicker from "./MultiplePicker";
import StringInputPicker from "./StringInputPicker";

const ShelterFilter = () => {
  const [location, setLocation] = useState("");
  const [distance, setDistance] = useState();
  const [name, setName] = useState("");

  return (
    <FilterWrapper>
      <FilterOption>
        <p className="filter-name">Lokacija</p>
        <p className="filter-explain">Upiši lokaciju</p>
        <StringInputPicker value={location} setValue={setLocation} placeholder="Upiši lokaciju"/>
      </FilterOption>
      <FilterOption>
        <p className="filter-name">Udaljenost</p>
        <p className="filter-explain">Upiši udaljenost</p>
        <StringInputPicker value={distance} setValue={setDistance} placeholder="Upiši maksimalnu udaljenost u km"/>
      </FilterOption>
      <FilterOption>
        <p className="filter-name">Naziv</p>
        <p className="filter-explain">Upiši naziv</p>
        <StringInputPicker value={name} setValue={setName} placeholder="Upiši naziv"/>
      </FilterOption>
    </FilterWrapper>
  )
}

export default ShelterFilter;