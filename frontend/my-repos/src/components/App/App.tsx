import './App.css'
import { Route, Routes} from "react-router";
import Layout from '../Layout/Layout';
import Main from '../Main/Main';
import RepositoryProvider from '../../contexts/RepositoryContext';

function App() {
  return (
    <RepositoryProvider>
      <div className="page">
        <Routes>
          <Route path="/" element={ <Layout /> }>
            <Route index element={ <Main /> } />
          </Route>
        </Routes>
      </div>
    </RepositoryProvider>
  )
}

export default App
