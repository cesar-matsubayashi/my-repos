import './RepositoryList.css'
import RepositoryCard from './RepositoryCard/RepositoryCard';
import { useState } from 'react';
import Pagination from './Pagination/Pagination';
import type { RepositoryResponse } from '../../utils/api';

interface RepositoryListProps {
  repositories: RepositoryResponse[];
}

export default function RepositoryList({ repositories = [] }: RepositoryListProps) {
  const [ currentPage, setCurrentPage ] = useState(1);
  const itemsPerPage = 10;
  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentItems = repositories.slice(startIndex, startIndex + itemsPerPage);
  const totalPages = Math.ceil(repositories.length / itemsPerPage);

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
        onPageChange={(page) => setCurrentPage(page)}
      />
    </section>
  );
}