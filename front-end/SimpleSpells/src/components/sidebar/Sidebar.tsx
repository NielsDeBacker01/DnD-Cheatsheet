import { Trash2 } from 'lucide-react';
import { useCurrentCharacter } from '../../context/CharacterContext';
import { Character, CharacterClass } from '../../types/Character';
import { characterService } from '../../services/CharacterService';
import './Sidebar.css'

function Sidebar() {
    const { setCurrentCharacter, allCharacters, refreshCharacters } = useCurrentCharacter();

    const handleNewCharacter = async () => {
        const newCharacter: Character = {
            id: -1,
            name: "New character",
            level: 1,
            spellAtkBonus: 0,
            class: CharacterClass.Wizard,                
            spellIds: []
        };
        setCurrentCharacter(newCharacter);
    }

    const handleDeleteCharacter = async (id: number) => {
        const success = await characterService.deleteCharacter(id);
        await refreshCharacters();
        if (success) {
            handleNewCharacter();
            console.log(`Deleted character ${id}`);
        }
    }

    return(
        <div className="sidebar border-orange-400 border-4 border-l-0 rounded-2xl rounded-l-none">
            {!allCharacters ? <p>No characters available</p> : 
            <ul>
                {allCharacters.map((char) => (
                <li key={char.id} onClick={() => setCurrentCharacter(char)} className="p-2 pl-3 border-b border-gray-300">
                    <div className="flex">
                        <p className="cursor-pointer hover:text-orange-500">{char.name}</p>
                        <button onClick={async () => {handleDeleteCharacter(char.id)}} className="special-button cursor-pointer p-0 rounded ml-auto hover:text-red-500"> <Trash2 className="w-5 h-5"/> </button>
                    </div>
                </li>
                ))}
            </ul>
            }
            <div className="flex justify-center mt-4">
                <button onClick={handleNewCharacter}> New Character </button>
            </div>
        </div>
    );
}

export default Sidebar;
