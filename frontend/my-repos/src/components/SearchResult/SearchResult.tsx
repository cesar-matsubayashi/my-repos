import RepositoryList from "../RepositoryList/RepositoryList";
import "./SearchResult.css";
import { useRepository } from "../../contexts/RepositoryContext";

export default function SearchResult() {
  const { searchList } = useRepository();
  
  return (
    <section className="search-result">
      <RepositoryList 
        repositories={searchList.projects} 
        searchPage={true} 
        totalSearchCount={searchList.totalCount}/>
    </section>
  );
}