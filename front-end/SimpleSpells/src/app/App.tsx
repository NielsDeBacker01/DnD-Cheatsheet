import Cheatsheet from '../components/cheatsheet/Cheatsheet';
import { CharacterProvider } from '../context/CharacterContext';
import { SpellProvider } from '../context/SpellContext';

const App = () => {
  return (
    <SpellProvider>
      <CharacterProvider>
        <div className="App">
          <Cheatsheet></Cheatsheet>
        </div>
      </CharacterProvider>
    </SpellProvider>
  );
};

export default App;
