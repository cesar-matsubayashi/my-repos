import './App.css'
import { Route, Routes} from "react-router-dom";
import Layout from '../Layout/Layout';
import Main from '../Main/Main';
import RepositoryProvider from '../../contexts/RepositoryContext';
import Favorites from '../Favorites/Favorites';
import MyRepositories from '../MyRepositories/MyRepositories';
import SearchResult from '../SearchResult/SearchResult';
import ModalProvider, { useModal } from '../../contexts/ModalContext';

function App() {

  return (
    <RepositoryProvider>
      <ModalProvider>
        <div className="page">
          <Routes>
            <Route path="/" element={ <Layout /> }>
              <Route index element={ <Main /> } />
              <Route path="/favoritos" element={ <Favorites /> } />
              <Route path="/meusrepositorios" element={ <MyRepositories /> } />
              <Route path="/search" element={ <SearchResult /> } />
            </Route>
          </Routes>
        </div>
      </ModalProvider>
    </RepositoryProvider>
  )
}

export default App
