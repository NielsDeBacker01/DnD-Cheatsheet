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
        <div className="body overflow-y-auto">
            <CharacterBar></CharacterBar>
            <div className="cheatsheet-spells p-4">
                <div className="mb-4 space-x-2">
                    {currentCharacter ? 
                        <button onClick={() => setLibraryToggle(false)} className={`${ libraryToggle === false ? "active-tab" : "inactive-tab"}`}>
                        Your Spells
                        </button> : null
                    }
                    <button onClick={() => setLibraryToggle(true)} className={`${ libraryToggle === true ? "active-tab" : "inactive-tab"}`}>
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