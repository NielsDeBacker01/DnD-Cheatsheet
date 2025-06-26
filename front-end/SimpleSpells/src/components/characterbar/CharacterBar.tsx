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
        //add alternative if currentCharacter has no id and use the add function.
        if ( form.name !== undefined && form.level !== undefined && form.spellAtkBonus !== undefined && currentCharacter !== undefined) 
        {
            //base for both new character or existing character
            const baseCharacter: Omit<Character, "id"> = {
                name: form.name,
                level: form.level,
                spellAtkBonus: form.spellAtkBonus,
                class: currentCharacter?.class,
                spellIds: currentCharacter?.spellIds ?? [],
            };
            //handle new character
            if(currentCharacter.id<0)
            {
                const createdCharacter = await characterService.createCharacter(baseCharacter);
                setCurrentCharacter(createdCharacter);
                console.log("New character created!", createdCharacter);            
            }
            //handle existing character
            else
            {
                const updatedCharacter: Character = {
                    id: currentCharacter.id,
                    ...baseCharacter,
                };
                setCurrentCharacter(updatedCharacter);
                await characterService.updateCharacter(updatedCharacter.id, updatedCharacter);
                console.log("Character updated!", updatedCharacter);
            }
            await refreshCharacters();
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
                <button onClick={handleSave} className="ml-auto">Save</button>
            </>
            }
        </div>
    );
}

export default CharacterBar;
