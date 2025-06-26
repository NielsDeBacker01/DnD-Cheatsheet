import { useEffect } from "react";
import { useSpells } from '../../context/SpellContext';
import SpellBlock from "../spellblock/SpellBlock";

//displays a list of spells to add/remove for the current character
function SpellLibrary() {
    const { spells, loading, error} = useSpells();

    useEffect(() => {
    }, []);

    if (loading) return <div>Loading spells...</div>;
    if (error) return <div>Error: {error}</div>;

    return(
        <div className="spell-library">
            <ul>
                {spells.map(spell => (
                <li key={spell.id}>
                    <SpellBlock spell={spell}/>
                </li>
                ))}
            </ul>
        </div>
    );
}

export default SpellLibrary;
