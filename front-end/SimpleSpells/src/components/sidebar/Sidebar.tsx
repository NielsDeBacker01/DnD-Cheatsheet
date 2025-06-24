import { useCurrentCharacter } from '../../context/CharacterContext';
import { characterService } from '../../services/CharacterService';
import { Character } from '../../types/Character';
import './Sidebar.css'
import { useEffect, useState } from "react";

//displays a list of spells to add/remove for the current character
function Sidebar() {
    const [characters, setCharacters] = useState<Character[]>([]);
    const { setCurrentCharacter } = useCurrentCharacter();

    useEffect(() => {
        const fetchCharacters = async () => {
        try {
            const data = await characterService.getAllCharacters();
            setCharacters(data);
        } catch (error) {
            console.error("Failed to fetch characters:", error);
        }
        };

        fetchCharacters();
    }, []);

    return(
        <div className="sidebar">
            {!characters ? <p>No characters available</p> : 
            <ul>
                {characters.map((char) => (
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
