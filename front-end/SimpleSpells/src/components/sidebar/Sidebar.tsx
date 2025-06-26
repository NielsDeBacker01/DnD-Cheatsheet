import { useCurrentCharacter } from '../../context/CharacterContext';
import { Character, CharacterClass } from '../../types/Character';
import './Sidebar.css'

//displays a list of spells to add/remove for the current character
function Sidebar() {
    const { setCurrentCharacter, allCharacters } = useCurrentCharacter();

    const handleNewCharacter = async () => {
        const newCharacter: Character = {
            id: -1,
            name: "",
            level: 1,
            spellAtkBonus: 0,
            class: CharacterClass.Wizard,                
            spellIds: []
        };
        setCurrentCharacter(newCharacter);
}

    return(
        <div className="sidebar border-orange-400 border-4 border-l-0 rounded-2xl rounded-l-none">
            {!allCharacters ? <p>No characters available</p> : 
            <ul>
                {allCharacters.map((char) => (
                <li key={char.id} onClick={() => setCurrentCharacter(char)} className="cursor-pointer p-2 pl-3 border-b border-gray-300">
                    {char.name}
                </li>
                ))}
            </ul>
            }
            <div className="flex justify-center mt-4">
                <button onClick={handleNewCharacter} className="px-4 py-2 rounded"> New Character </button>
            </div>
        </div>
    );
}

export default Sidebar;
