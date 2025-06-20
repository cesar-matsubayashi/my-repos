import './Main.css'
import AddForm from "./AddForm/AddForm";
import RepositoryCard from '../RepositoryCard/RepositoryCard';
import { useRepository } from '../../contexts/RepositoryContext';
import { useState } from 'react';
import Pagination from '../Pagination/Pagination';

export default function Main() {
  const { repositoryList } = useRepository();
  const [ currentPage, setCurrentPage ] = useState(1);
  const itemsPerPage = 10;
  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentItems = repositoryList.slice(startIndex, startIndex + itemsPerPage);
  const totalPages = Math.ceil(repositoryList.length / itemsPerPage);

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
      <section className='repositories'>
        <div className='repositories__card'>
          {currentItems.map((repository) => (
            <RepositoryCard key={repository.id} repository={repository}/>
          ))}
        </div>
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          onPageChange={(page) => setCurrentPage(page)}
        />
      </section>
    </main>
  );
}