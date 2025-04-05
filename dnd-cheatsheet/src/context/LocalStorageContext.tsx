import { createContext, useContext, useState, useEffect } from 'react';
import { getFromLocalStorage, setToLocalStorage } from '../utils/LocalStorageUtils';
import { Character } from '../types';

// create the context (structure and default values)
const LocalStorageContext = createContext<{
  character: Character;
  saveCharacter: (newCharacter: Character) => void;
}>({
  character: {
    name: "Aria Windrunner",
    classes: { wizard: 5, rogue: 2 },
    knownSpells: ["Mage Hand", "Fireball", "Shield"],
    features: ["Sneak Attack", "Arcane Recovery"]
  },
  saveCharacter: () => {}
});

//function to export storage and use elsewhere
export const useLocalStorage = () => {
  return useContext(LocalStorageContext);
};

export const LocalStorageProvider = ({ children }: { children: React.ReactNode }) => {
    //gets the character on startup ONCE or replaces it with aria if empty and stores it in a state
  const [character, setCharacter] = useState<Character>(() => {
    const saved = getFromLocalStorage('myCharacter');
    return saved || {
      name: "Aria Windrunner",
      classes: { wizard: 5, rogue: 2 },
      knownSpells: ["Mage Hand", "Fireball", "Shield"],
      features: ["Sneak Attack", "Arcane Recovery"]
    };
  });

  //save aria as default in the local storage on startup
  useEffect(() => {
    setToLocalStorage('myCharacter', character);
  }, [character]);

  //function for updating the character
  const saveCharacter = (newCharacter: Character) => {
    setCharacter(newCharacter);
  };

  //container for global usage
  return (
    <LocalStorageContext.Provider value={{ character, saveCharacter }}>
      {children}
    </LocalStorageContext.Provider>
  );
};
 