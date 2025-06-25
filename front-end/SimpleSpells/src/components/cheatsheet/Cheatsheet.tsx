import './Cheatsheet.css';
import { useEffect, useState } from "react";
import SpellLibrary from "../spelllibrary/Spelllibrary";
import CharacterBar from "../characterbar/CharacterBar";
import SpellBook from "../spellbook/SpellBook";
import { useCurrentCharacter } from "../../context/CharacterContext";

function Cheatsheet() {
    const [ libraryToggle, setLibraryToggle] = useState(false);
    const { currentCharacter } = useCurrentCharacter();

    useEffect(() => {
    }, []);

    return (
        <div className="body">
            <CharacterBar></CharacterBar>
            <div className="cheatsheet-spells">
                <div className="mb-4 space-x-2">
                    {currentCharacter ? 
                        <button onClick={() => setLibraryToggle(false)} className={`px-4 py-2 rounded ${ libraryToggle === false ? "bg-blue-500 text-white" : "bg-gray-200"}`}>
                        Your Spells
                        </button> : null
                    }
                    <button onClick={() => setLibraryToggle(true)} className={`px-4 py-2 rounded ${ libraryToggle === true ? "bg-green-500 text-white" : "bg-gray-200"}`}>
                    Manage Spells
                    </button>
                </div>
                {!currentCharacter ? <p>Spells can't be displayed: No Character is currently selected</p> : 
                <div className="cheatsheet-spelltab">
                    {libraryToggle ? <SpellLibrary /> : <SpellBook />}
                </div>
                }
            </div>
        </div>
    );
}

export default Cheatsheet;