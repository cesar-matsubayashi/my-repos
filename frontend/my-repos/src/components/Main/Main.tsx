import './Main.css'
import AddForm from "./AddForm/AddForm";
import { useRepository } from '../../contexts/RepositoryContext';
import RepositoryList from '../RepositoryList/RepositoryList';

export default function Main() {
  const { repositoryList } = useRepository();

  return (
    <main className="main">
      <section className="intro">
        <h1 className="intro__headline">
          Organize e adicione seus repositórios aqui!
        </h1>
        <p className="intro__caption">
          Gerencie facilmente seus repositórios do GitHub em um só lugar. 
          Mantenha seus favoritos por perto — 
          basta colar o link de um repositório aqui para começar.
        </p>
        <AddForm />
      </section>
      <RepositoryList repositories={repositoryList}/>
    </main>
  );
}