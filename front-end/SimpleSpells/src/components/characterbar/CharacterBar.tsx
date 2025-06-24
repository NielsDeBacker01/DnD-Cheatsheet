import { useEffect } from "react";
import { useCurrentCharacter } from "../../context/CharacterContext";

//displays a list of spells to add/remove for the current character
function CharacterBar() {
    const { currentCharacter} = useCurrentCharacter();
    
    useEffect(() => {
    }, []);

    return(
        <div className="character-bar flex w-full items-start p-3">
            {!currentCharacter ? <p>Handle no current character not currently implemented for top bar</p> : 
            <>
                <p className="h-[40%] flex items-end pr-[2rem] text-2xl font-bold">{currentCharacter.name} Lvl: {currentCharacter.level}</p>
                <div className="h-[40%] flex pt-1rem items-end">
                    <p className="pr-[1rem]">SpellAtk:</p>
                    <input type="number" className="text-right border border-gray-300 rounded" value={currentCharacter.spellAtkBonus} min={0} max={20}></input>
                </div>
            </>
            }
        </div>
    );
}

export default CharacterBar;
