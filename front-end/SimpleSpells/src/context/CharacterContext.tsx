import React, { createContext, useContext, useState, ReactNode } from 'react';
import { Character } from '../types/Character';

//establish context and it's values
interface CharacterContextType {
    currentCharacter: Character | undefined;
    setCurrentCharacter: (character: Character) => void;
}
const CharacterContext = createContext<CharacterContextType | undefined>(undefined);

//provider for the context that wraps around app
interface CharacterProviderProps {children: ReactNode;}
export const CharacterProvider: React.FC<CharacterProviderProps> = ({ children }) => { 
    //set state for the context values
    const [currentCharacter, setCurrentCharacter] = useState<Character>();

    //load the states/functions into the context
    const value: CharacterContextType = {
        currentCharacter,
        setCurrentCharacter,
    };

    return (
        <CharacterContext.Provider value={value}>
        {children}
        </CharacterContext.Provider>
    );
};

// Custom hook to use the character context in components
export const useCurrentCharacter = (): CharacterContextType => {
    const context = useContext(CharacterContext);
    if (context === undefined) {
        throw new Error('useCharacter must be used within a CharacterProvider');
    }
    return context;
};