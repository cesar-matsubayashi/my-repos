import { useEffect } from "react";
import RepositoryList from "../RepositoryList/RepositoryList";
import "./MyRepositories.css";
import { useRepository } from "../../contexts/RepositoryContext";

export default function MyRepositories() {
  const { myRepositories, myRepositoryList } = useRepository();

  useEffect(() => {
    myRepositories();
  }, []);
  
  return (
    <section className="my-repositories">
      <RepositoryList repositories={myRepositoryList}/>
    </section>
  );
}