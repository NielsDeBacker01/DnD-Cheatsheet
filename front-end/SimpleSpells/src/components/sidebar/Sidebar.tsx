import { useCurrentCharacter } from '../../context/CharacterContext';
import './Sidebar.css'

//displays a list of spells to add/remove for the current character
function Sidebar() {
    const { setCurrentCharacter, allCharacters } = useCurrentCharacter();

    return(
        <div className="sidebar border-orange-400 border-4 border-l-0 rounded-2xl rounded-l-none">
            {!allCharacters ? <p>No characters available</p> : 
            <ul>
                {allCharacters.map((char) => (
                <li key={char.id} onClick={() => setCurrentCharacter(char)} className="cursor-pointer p-2 border-b border-gray-300">
                    {char.name}
                </li>
                ))}
            </ul>
            }
        </div>
    );
}

export default Sidebar;
