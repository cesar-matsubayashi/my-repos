import { useEffect } from "react";
import RepositoryList from "../RepositoryList/RepositoryList";
import "./Favorites.css";
import { useRepository } from "../../contexts/RepositoryContext";


export default function Favorites() {
  const { myFavorites, favoritesList } = useRepository();
  
  useEffect(() => {
    myFavorites();
  }, []);
  
  return (
    <section className="favorites">
      <RepositoryList repositories={favoritesList}/>
    </section>
  );
}