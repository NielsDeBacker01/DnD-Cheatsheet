import { useEffect, useState } from "react";
import { useCurrentCharacter } from "../../context/CharacterContext";
import { characterService } from "../../services/CharacterService";
import { Character } from "../../types/Character";

//displays a list of spells to add/remove for the current character
function CharacterBar() {
    const { currentCharacter, setCurrentCharacter, refreshCharacters } = useCurrentCharacter();
    
    useEffect(() => {
        if (currentCharacter) {
            setForm({
                name: currentCharacter.name,
                level: currentCharacter.level,
                spellAtkBonus: currentCharacter.spellAtkBonus,
            });
        }
    }, [currentCharacter]);

    const [form, setForm] = useState({
        name: currentCharacter?.name,
        level: currentCharacter?.level,
        spellAtkBonus: currentCharacter?.spellAtkBonus
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSave = async () => {
        if ( form.name !== undefined && form.level !== undefined && form.spellAtkBonus !== undefined && currentCharacter !== undefined) 
        {
            const updatedCharacter: Character = {
                id: currentCharacter.id,
                name: form.name,
                level: form.level,
                spellAtkBonus: form.spellAtkBonus,
                class: currentCharacter.class,                
                spellIds: currentCharacter.spellIds
            };
            setCurrentCharacter(updatedCharacter);
            await characterService.updateCharacter(updatedCharacter.id, updatedCharacter);
            await refreshCharacters();
            console.log("Character updated!", updatedCharacter);
        } else {
            console.error("Missing required character fields.");
        }
    };

    return(
        <div className="character-bar flex w-full items-start p-3 border-b-orange-400 border-b-1">
            {!currentCharacter ? <p>Handle no current character not currently implemented for top bar</p> : 
            <>
                <div className="flex items-end">
                    <input type="text" className="text-xl border border-gray-300 rounded mr-6 pl-2 font-bold" name="name" value={form.name ?? ""} onChange={handleChange}></input>
                    <p className="mr-2  font-bold">Lvl:</p>
                    <input type="number" className="mr-4 text-right border border-gray-300 rounded" name="level" value={form.level ?? 0} onChange={handleChange} min={0} max={20}></input>
                    <p className="mr-[1rem]">SpellAtk:</p>
                    <input type="number" className="text-right border border-gray-300 rounded" name="spellAtkBonus" value={form.spellAtkBonus ?? 0} onChange={handleChange} min={0} max={20}></input>
                </div>
                <button onClick={handleSave} className="ml-auto bg-orange-500">Save</button>
            </>
            }
        </div>
    );
}

export default CharacterBar;
