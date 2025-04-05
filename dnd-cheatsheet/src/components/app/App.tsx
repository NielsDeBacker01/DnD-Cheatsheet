import React, { useState, useEffect } from "react";
import { useLocalStorage } from '../../context/LocalStorageContext';

const App = () => {
  const { character, saveCharacter } = useLocalStorage();

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
      <button
        onClick={() => {
          // Example of modifying the character data
          const updatedCharacter = { ...character, name: "New Name" };
          saveCharacter(updatedCharacter);
        }}
      >
        Remove Name
      </button>
    </div>
  );
};

export default App;
