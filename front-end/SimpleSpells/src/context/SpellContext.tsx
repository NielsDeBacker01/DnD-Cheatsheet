import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { Spell } from '../types/Spell';
import { SpellService } from '../services/SpellService';

//establish context and it's values
interface SpellContextType {
    spells: Spell[];
    loading: boolean;
    error: string | null;
    refreshSpells: () => Promise<void>;
}
const SpellContext = createContext<SpellContextType | undefined>(undefined);

//service outside of provider as it shouldn't be reloaded
const spellService = new SpellService();

//provider for the context that wraps around app
interface SpellProviderProps {children: ReactNode;}
export const SpellProvider: React.FC<SpellProviderProps> = ({ children }) => { 
    //set state for the context values
    const [spells, setSpells] = useState<Spell[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    //function for getting the spells
    const fetchSpells = async () => {
        try {
            setLoading(true);
            setError(null);
            const fetchedSpells = await spellService.getAllSpells();
            setSpells(fetchedSpells);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to fetch spells');
        } finally {
            setLoading(false);
        }
    };

    //fetch on startup
    useEffect(() => {
        fetchSpells();
    }, []);

    //load the states/functions into the context
    const value: SpellContextType = {
        spells,
        loading,
        error,
        refreshSpells: fetchSpells,
    };

    return (
        <SpellContext.Provider value={value}>
        {children}
        </SpellContext.Provider>
    );
};

// Custom hook to use the spell context in components
export const useSpells = (): SpellContextType => {
    const context = useContext(SpellContext);
    if (context === undefined) {
        throw new Error('useSpells must be used within a SpellProvider');
    }
    return context;
};