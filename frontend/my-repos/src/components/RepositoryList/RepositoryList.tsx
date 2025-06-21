import './RepositoryList.css'
import RepositoryCard from './RepositoryCard/RepositoryCard';
import { useState } from 'react';
import Pagination from './Pagination/Pagination';
import type { RepositoryResponse } from '../../utils/api';
import { useRepository } from '../../contexts/RepositoryContext';

interface RepositoryListProps {
  repositories: RepositoryResponse[];
  searchPage?: boolean;
  totalSearchCount?: number
}

export default function RepositoryList({ 
  repositories = [], 
  searchPage = false,
  totalSearchCount = 0 }: RepositoryListProps) {

  const [ currentPage, setCurrentPage ] = useState(1);
  const itemsPerPage = 10;
  const startIndex = (currentPage - 1) * itemsPerPage;
  const { searchRepositories, searchValue } = useRepository();
  
  let currentItems: RepositoryResponse[]; 
  let totalPages: number;
  if(searchPage){
    currentItems = repositories;
    totalPages = Math.ceil(totalSearchCount/ itemsPerPage);
  }else{
    currentItems = repositories.slice(startIndex, startIndex + itemsPerPage);
    totalPages = Math.ceil(repositories.length/ itemsPerPage);
  }


  const handlePageChange = (page: number) => {
    setCurrentPage(page)

    if(searchPage){
      searchRepositories(searchValue, page);
    }
  }

  return (
    <section className='repositories'>
      <div className='repositories__card'>
        {currentItems.map((repository) => (
          <RepositoryCard key={repository.id} repository={repository}/>
        ))}
      </div>
      <Pagination
        currentPage={currentPage}
        totalPages={totalPages}
        onPageChange={(page) => handlePageChange(page)}
        searchPage={searchPage}
      />
    </section>
  );
}