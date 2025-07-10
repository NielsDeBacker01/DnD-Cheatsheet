import './Spelllibrary.css';
import SpellBlock from "../spellblock/SpellBlock";
import { useEffect } from "react";
import { useSpells } from '../../context/SpellContext';
import { useCurrentCharacter } from "../../context/CharacterContext";
import { Character } from "../../types/Character";


function SpellLibrary() {
    const { currentCharacter, setCurrentCharacter } = useCurrentCharacter();
    const { spells, loading, error} = useSpells();

    useEffect(() => {
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>, spellId: number) => {
        if (!currentCharacter) {
            throw new Error('no character is currently selected');
        }
        const newSpellList: number[] | undefined 
            = e.target.checked 
                ? Array.from(new Set([...currentCharacter.spellIds, spellId]))
                : currentCharacter.spellIds.filter(s => s != spellId)

        const updatedCharacter: Character = {
            ...currentCharacter,
            spellIds: newSpellList ?? [],
        };
        setCurrentCharacter(updatedCharacter);
    };

    if (loading) return <div>Loading spells...</div>;
    if (error) return <div>Error: {error}</div>;

    return(
        <div className="spell-library">
            <ul>
                {spells.map(spell => (
                <li key={spell.id} className="flex mr-2 items-center">
                    <div className="flex rounded-l border-2 spell-block border-r-0 p-2 m-0">
                        <input type="checkbox" className="accent-orange-500" name={spell.name} checked={currentCharacter?.spellIds.includes(spell.id)} onChange={(e) => handleChange(e, spell.id)}/>
                    </div>
                    <SpellBlock spell={spell}/>
                </li>
                ))}
            </ul>
        </div>
    );
}

export default SpellLibrary;
