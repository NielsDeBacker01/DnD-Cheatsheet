import { createRoot } from 'react-dom/client'
import './index.css'
import App from './components/app/App.tsx'
import { LocalStorageProvider } from './context/LocalStorageContext';

createRoot(document.getElementById('root')!).render(
  <LocalStorageProvider>
    <App />
  </LocalStorageProvider>,
)
