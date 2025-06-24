import { useEffect } from "react";
import SpellLibrary from "../spelllibrary/Spelllibrary";
import CharacterBar from "../characterbar/CharacterBar";
import SpellBook from "../spellbook/SpellBook";
import { useCurrentCharacter } from "../../context/CharacterContext";
import Sidebar from "../sidebar/Sidebar";

function Cheatsheet() {
  
  const { currentCharacter, loading, error} = useCurrentCharacter();

  useEffect(() => {
  }, []);

  let content
  if (!currentCharacter)
  {
    content = <div>No Character is currently selected</div>
  } 
  else
  {
    if (loading) content = <div>Loading Character...</div>;
    if (error) content = <div>Error: {error}</div>;
    content = (
    <div className="cheatsheet-main">
        <SpellBook></SpellBook>
        <SpellLibrary></SpellLibrary>
    </div>
    )
  }

  return (
    <div className="cheatsheet">
      <Sidebar></Sidebar>
      <CharacterBar></CharacterBar>
      {content}
    </div>
  );
}

export default Cheatsheet;
