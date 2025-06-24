import { useEffect } from "react";
import { useCurrentCharacter } from "../../context/CharacterContext";

//displays a list of spells to add/remove for the current character
function CharacterBar() {
    const { currentCharacter, loading, error} = useCurrentCharacter();
    
    useEffect(() => {
    }, []);

    let content
    if (!currentCharacter)
    {
        content = <div>Handle no current character not currently implemented for top bar</div>
    } 
    else
    {
        if (loading) content = <div>Loading Character...</div>;
        if (error) content = <div>Error: {error}</div>;
        content = (
            <div>
                <h1>{currentCharacter.name} Lvl: {currentCharacter.level}</h1>
                <div>
                    <h2>SpellAtk:</h2>
                    <input type="number" value={currentCharacter.spellAtkBonus} min={0} max={20}></input>
                </div>
                <div>
                    <h2>Spells:</h2>
                    <ul>
                    {currentCharacter.spells.map(spell => <li key={spell}>{spell}</li>)}
                    </ul>
                </div>
            </div>
        )
    }

    return(
        <div className="character-bar">
            {content}
        </div>
    );
}

export default CharacterBar;
