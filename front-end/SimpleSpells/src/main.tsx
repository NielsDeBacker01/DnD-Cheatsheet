import { createRoot } from 'react-dom/client'
import './index.css'
import App from './app/App.tsx'
import { LocalStorageProvider } from './context/LocalStorageContext.tsx';

createRoot(document.getElementById('root')!).render(
  <LocalStorageProvider>
    <App />
  </LocalStorageProvider>,
)
