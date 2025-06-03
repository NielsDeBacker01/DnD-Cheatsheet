import { createContext, useContext, useState, useEffect } from 'react';
import { getFromLocalStorage, setToLocalStorage } from '../utils/LocalStorageUtils';
import { Character } from '../types';

const defaultCharacter: Character = {
  name: "Your Character",
  level: 1,
  spellAtk: 0,
  knownSpells: ["Fire bolt", "Fireball", "Shield"],
};

// create the context (structure and default values)
const LocalStorageContext = createContext<{
  character: Character;
  saveCharacter: (newCharacter: Character) => void;
}>({
  character: defaultCharacter,
  saveCharacter: () => {}
});

//function to export storage and use elsewhere
export const useLocalStorage = () => {
  return useContext(LocalStorageContext);
};

export const LocalStorageProvider = ({ children }: { children: React.ReactNode }) => {
  //gets the saved character from storage on startup ONCE and stores it in a state
  const [character, setCharacter] = useState<Character>(() => {
    const saved = getFromLocalStorage('myCharacter');
    return saved ?? defaultCharacter;
  });

  //when character is changed (see dependency at end [character]) --> set what happens (set local)
  useEffect(() => {
    setToLocalStorage('myCharacter', character);
  }, [character]);

  //function for updating the character state -> triggers use effect because of set defined in state
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
 