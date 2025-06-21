import './Pagination.css';
import { useRepository } from '../../../contexts/RepositoryContext';

interface PaginationProps {
      currentPage: number;
      totalPages: number;
      onPageChange: (page: number) => void;
      siblingCount?: number;
      searchPage: boolean
    }

export default function Pagination({
  currentPage,
  totalPages,
  onPageChange,
  siblingCount = 2,
  searchPage = false
}: PaginationProps){
  
   const { searchRepositories, searchValue } = useRepository();
  
  if (totalPages <= 1) return null;

  const range = (start: number, end: number) => {
    const length = end - start + 1;
    return Array.from({ length }, (_, i) => start + i);
  };

  const getPaginationItems = () => {
    const totalPageShown = siblingCount * 2 + 1;

    if (totalPages <= totalPageShown) {
      return range(1, totalPages);
    }

    const leftSiblingIndex = Math.max(currentPage - siblingCount, 1);
    const rightSiblingIndex = Math.min(currentPage + siblingCount, totalPages);

    const shouldShowLeftDots = leftSiblingIndex > 1;
    const shouldShowRightDots = rightSiblingIndex < totalPages - 1;

    if (!shouldShowLeftDots && shouldShowRightDots) {
      const leftRange = range(1, totalPageShown);
      return [...leftRange, '...', totalPages];
    }

    if (shouldShowLeftDots && !shouldShowRightDots) {
      const rightRange = range(totalPages - siblingCount - 2, totalPages);
      return [1, '...', ...rightRange];
    }

    if (shouldShowLeftDots && shouldShowRightDots) {
      const middleRange = range(leftSiblingIndex, rightSiblingIndex);
      return [1, '...', ...middleRange, '...', totalPages];
    }

    return range(1, totalPages);
  };

  const handlePrevClick = () => {
    if (currentPage > 1) {
      if(searchPage){
        searchRepositories(searchValue, currentPage);
      }else{
        onPageChange(currentPage - 1);
      }
    }
  };

  const handleNextClick = () => {
    if (currentPage < totalPages) {
      onPageChange(currentPage + 1);
    }
  };

  return (
    <nav className="pagination-container">
      <ul className="pagination">
        <li className={`page-item ${currentPage === 1 ? 'disabled' : ''}`}>
          <a className="page-link" onClick={handlePrevClick}>&lt;</a>
        </li>
        
        {getPaginationItems().map((item, index) => (
          <li 
            key={index} 
            className={`page-item ${item === currentPage ? 'active' : ''}`}
          >
            {item === '...' ? (
              <span className="ellipsis">...</span>
            ) : (
              <a 
                className="page-link" 
                onClick={() => typeof item === 'number' && onPageChange(item)}
              >
                {item}
              </a>
            )}
          </li>
        ))}
        
        <li className={`page-item ${currentPage === totalPages ? 'disabled' : ''}`}>
          <a className="page-link" onClick={handleNextClick}>&gt;</a>
        </li>
      </ul>
    </nav>
  );
};