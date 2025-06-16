import React, { createContext, useContext, useState, ReactNode } from 'react';
import { CharacterService } from '../services/CharacterService';
import { Character } from '../types/Character';

//establish context and it's values
interface CharacterContextType {
    currentCharacter: Character | undefined;
    loading: boolean;
    error: string | null;
    loadCharacter: (id: number) => Promise<void>;
}
const CharacterContext = createContext<CharacterContextType | undefined>(undefined);

//service outside of provider as it shouldn't be reloaded
const characterService = new CharacterService();

//provider for the context that wraps around app
interface CharacterProviderProps {children: ReactNode;}
export const CharacterProvider: React.FC<CharacterProviderProps> = ({ children }) => { 
    //set state for the context values
    const [currentCharacter, setCurrentCharacter] = useState<Character>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    //function for getting the character
    const fetchCharacterById = async (id: number) => {
        try {
            setLoading(true);
            setError(null);
            const fetchedCharacter = await characterService.getCharacterById(id);
            setCurrentCharacter(fetchedCharacter);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to fetch character(id:' + id + ')');
        } finally {
            setLoading(false);
        }
    };

    //load the states/functions into the context
    const value: CharacterContextType = {
        currentCharacter,
        loading,
        error,
        loadCharacter: fetchCharacterById,
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