import './App.css';
import Cheatsheet from '../components/cheatsheet/Cheatsheet';
import { CharacterProvider } from '../context/CharacterContext';
import { SpellProvider } from '../context/SpellContext';
import Sidebar from '../components/sidebar/Sidebar';

const App = () => {
  return (
    <SpellProvider>
      <CharacterProvider>
        <div className="app">
          <Sidebar></Sidebar>
          <div className="body">
            <Cheatsheet></Cheatsheet>
          </div>
        </div>
      </CharacterProvider>
    </SpellProvider>
  );
};

export default App;
