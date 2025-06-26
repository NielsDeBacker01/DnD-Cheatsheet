import { useEffect } from "react";
import { useCurrentCharacter } from "../../context/CharacterContext";
import { useSpells } from "../../context/SpellContext";
import SpellBlock from "../spellblock/SpellBlock";

//displays a list of spells to add/remove for the current character
function SpellBook() {
    const { currentCharacter } = useCurrentCharacter();
    const { spells, loading } = useSpells();

    useEffect(() => {
    }, []);

    if (!currentCharacter || loading || !Array.isArray(currentCharacter.spellIds)) return null;
    const characterSpells = spells.filter(spell =>
        currentCharacter.spellIds.includes(spell.id)
    );

    return(
        <div className="spell-book">
            {currentCharacter ? 
                <ul>
                    {characterSpells.map(spell => (
                    <li key={spell.id}>
                        <SpellBlock spell={spell}/>
                    </li>
                    ))}
                </ul> 
            : null}
        </div>
    );
}

export default SpellBook;
