import './Cheatsheet.css';
import { useEffect } from "react";
import SpellLibrary from "../spelllibrary/Spelllibrary";
import CharacterBar from "../characterbar/CharacterBar";
import SpellBook from "../spellbook/SpellBook";
import { useCurrentCharacter } from "../../context/CharacterContext";

function Cheatsheet() {
    const { currentCharacter } = useCurrentCharacter();

    useEffect(() => {
    }, []);

    return (
        <div className="body">
            <CharacterBar></CharacterBar>
            <div className="cheatsheet-spells">
                {!currentCharacter ? <p>Spells can't be displayed: No Character is currently selected</p> : 
                <div className="cheatsheet-spelltab">
                    <SpellBook></SpellBook>
                    <SpellLibrary></SpellLibrary>
                </div>
                }
            </div>
        </div>
    );
}

export default Cheatsheet;
