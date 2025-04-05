import React, { useState, useEffect } from "react";

type Character = {
  name: string;
  classes: Record<string, number>;
  knownSpells: string[];
  features: string[];
};

const defaultCharacter: Character = {
  name: "Aria Windrunner",
  classes: {
    wizard: 5,
    rogue: 2
  },
  knownSpells: ["Mage Hand", "Fireball", "Shield"],
  features: ["Sneak Attack", "Arcane Recovery"]
};

function App() {
  const [character, setCharacter] = useState<Character>(() => {
    const saved = localStorage.getItem("myCharacter");
    return saved ? JSON.parse(saved) : defaultCharacter;
  });

  useEffect(() => {
    localStorage.setItem("myCharacter", JSON.stringify(character));
  }, [character]);

  return (
    <div className="App">
      <h1>{character.name}</h1>
      <h2>Classes:</h2>
      <ul>
        {Object.entries(character.classes).map(([cls, lvl]) => (
          <li key={cls}>{cls}: Level {lvl}</li>
        ))}
      </ul>
      <h2>Spells:</h2>
      <ul>
        {character.knownSpells.map(spell => <li key={spell}>{spell}</li>)}
      </ul>
      <h2>Features:</h2>
      <ul>
        {character.features.map(f => <li key={f}>{f}</li>)}
      </ul>
    </div>
  );
}

export default App;
