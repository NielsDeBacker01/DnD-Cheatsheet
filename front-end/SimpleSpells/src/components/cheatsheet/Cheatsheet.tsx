import { useEffect, useState } from "react";
import SpellLibrary from "../spelllibrary/Spelllibrary";
//import { useCurrentCharacter } from "../../context/CharacterContext";

function Cheatsheet() {
  const [character, setCharacter] = useState({name: "placeholder", level: 0, spellAtk: 0, knownSpells: ["fire bolt"]});
  //const { currentCharacter, loading, error} = useCurrentCharacter();

  useEffect(() => {
  }, []);

  const handleSpellAtkChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = parseInt(e.target.value, 10);
    setCharacter({ ...character, spellAtk: newValue });
  };

  return (
    <div className="cheatsheet">
      <h1>{character.name} Lvl: {character.level}</h1>
      <div>
        <h2>SpellAtk:</h2>
        <input type="number" value={character.spellAtk} onChange={handleSpellAtkChange} min={0} max={20}></input>
      </div>
      <div>
        <h2>Spells:</h2>
        <ul>
          {character.knownSpells.map(spell => <li key={spell}>{spell}</li>)}
        </ul>
      </div>
      <SpellLibrary></SpellLibrary>
    </div>
  );
}

export default Cheatsheet;
