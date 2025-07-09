import './App.css'
import { Route, Routes} from "react-router-dom";
import Layout from '../Layout/Layout';
import Main from '../Main/Main';
import RepositoryProvider from '../../contexts/RepositoryContext';
import Favorites from '../Favorites/Favorites';
import MyRepositories from '../MyRepositories/MyRepositories';
import SearchResult from '../SearchResult/SearchResult';
import Modal from '../Modal/Modal';
import { useState } from 'react';

function App() {
  const [open, setOpen] = useState(false);

  return (
    <RepositoryProvider>
      <div className="page">
        <button onClick={() => setOpen(true)}>Open Modal</button>
        <Routes>
          <Route path="/" element={ <Layout /> }>
            <Route index element={ <Main /> } />
            <Route path="/favoritos" element={ <Favorites /> } />
            <Route path="/meusrepositorios" element={ <MyRepositories /> } />
            <Route path="/search" element={ <SearchResult /> } />
          </Route>
        </Routes>
      </div>
      <Modal isOpen={open} onClose={() => setOpen(false)}>
        <h2>Hello</h2>
      </Modal>
    </RepositoryProvider>
  )
}

export default App
