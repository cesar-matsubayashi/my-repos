import './App.css'
import { Route, Routes} from "react-router";
import Layout from '../Layout/Layout';

function App() {
  return (
    <div className="page">
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<main />} />
        </Route>
      </Routes>
    </div>
  )
}

export default App
