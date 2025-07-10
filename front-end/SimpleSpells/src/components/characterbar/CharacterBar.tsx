import './CharacterBar.css';
import { useEffect, useState } from "react";
import { useCurrentCharacter } from "../../context/CharacterContext";
import { characterService } from "../../services/CharacterService";
import { Character, CharacterClass } from "../../types/Character";

function CharacterBar() {
    const { currentCharacter, setCurrentCharacter, refreshCharacters } = useCurrentCharacter();
    
    useEffect(() => {
        if (currentCharacter) {
            setForm({
                name: currentCharacter.name,
                level: currentCharacter.level,
                spellAtkBonus: currentCharacter.spellAtkBonus,
                class: currentCharacter.class
            });
        }
    }, [currentCharacter]);

    const [form, setForm] = useState({
        name: currentCharacter?.name,
        level: currentCharacter?.level,
        spellAtkBonus: currentCharacter?.spellAtkBonus,
        class: currentCharacter?.class
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSave = async () => {
        if (!currentCharacter || Object.values(form).some(v => v === undefined))
        {
            console.error("Missing required character fields.");
            return;
        }
        //add alternative if currentCharacter has no id and use the add function.
        //base for both new character or existing character
        const baseCharacter: Omit<Character, "id"> = {
            name: form.name!,
            level: form.level!,
            spellAtkBonus: form.spellAtkBonus!,
            class: form.class!,
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
    };

    return(
        <div className="character-bar flex w-full items-start p-3 border-b-orange-400 border-b-1">
            {!currentCharacter ? <p>Handle no current character not currently implemented for top bar</p> : 
            <>
                <div className="flex items-end">
                    <input type="text" className="text-xl text-left mr-6 pl-2 font-bold" name="name" value={form.name ?? ""} onChange={handleChange}></input>
                    <p>Lvl:</p>
                    <input type="number" className="text-right w-10" name="level" value={form.level ?? 0} onChange={handleChange} min={0} max={20}></input>
                    <p>SpellAtk:</p>
                    <input type="number" className="text-right w-10" name="spellAtkBonus" value={form.spellAtkBonus ?? 0} onChange={handleChange} min={0} max={20}></input>
                    <p>Class:</p>
                    <select className="border rounded" name="class" value={form.class} onChange={handleChange}>
                        {Object.values(CharacterClass).map((charClass) => (
                            <option key={charClass} value={charClass}>
                                {charClass}
                            </option>
                        ))}
                    </select>
                </div>
                <button onClick={handleSave} className="ml-auto">Save</button>
            </>
            }
        </div>
    );
}

export default CharacterBar;
