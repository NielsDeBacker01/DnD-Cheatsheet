import { useLocalStorage } from '../../context/LocalStorageContext';

function Cheatsheet() {
  const { character, saveCharacter } = useLocalStorage();

  const handleSpellAtkChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const newValue = parseInt(e.target.value, 10);
    saveCharacter({ ...character, spellAtk: newValue });
  };

  return (
    <div className="Cheatsheet">
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
      <button
        onClick={() => {
          let newSpell: string = "";
          switch (character.knownSpells[0]) {
            case "Fire Bolt":
              newSpell = "Eldritch Blast";
              break;
            case "Eldritch Blast":
              newSpell = "Acid Splash";
              break;
            case "Acid Splash":
              newSpell = "Fire Bolt";
              break;
            default:
              newSpell = "Fallback spell"
              break;
          }
          saveCharacter({...character, knownSpells: [newSpell, ...character.knownSpells.slice(1)]});
        }}
      >
        toggle cantrip
      </button>
    </div>
  );
}

export default Cheatsheet;
