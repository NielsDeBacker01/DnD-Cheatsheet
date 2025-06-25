import React, { createContext, useContext, useState, ReactNode, useEffect } from 'react';
import { Character } from '../types/Character';
import { characterService } from '../services/CharacterService';

//establish context and it's values
interface CharacterContextType {
    currentCharacter: Character | undefined;
    setCurrentCharacter: (character: Character) => void;
    allCharacters: Character[];
    refreshCharacters: () => Promise<void>;
}

const CharacterContext = createContext<CharacterContextType | undefined>(undefined);

//provider for the context that wraps around app
interface CharacterProviderProps {children: ReactNode;}
export const CharacterProvider: React.FC<CharacterProviderProps> = ({ children }) => { 
    //set state for the context values
    const [currentCharacter, setCurrentCharacter] = useState<Character>();
    const [allCharacters, setCharacters] = useState<Character[]>([]);

    const refreshCharacters = async () => {
        try {
            const allChars = await characterService.getAllCharacters();
            setCharacters(allChars);
            
            //update currentcharacter in case of new data
            if (currentCharacter) {
                const updated = allChars.find(c => c.id === currentCharacter.id);
                if (updated) setCurrentCharacter(updated);
            }
        } catch (err) {
            console.error("Failed to fetch characters:", err);
        }
    };

    useEffect(() => {
        refreshCharacters();
    }, []);

    //load the states/functions into the context
    const value: CharacterContextType = {
        currentCharacter,
        setCurrentCharacter,
        allCharacters,
        refreshCharacters
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