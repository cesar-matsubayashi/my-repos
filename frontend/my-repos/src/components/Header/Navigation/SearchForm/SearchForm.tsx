import "../../../../styles/Form.css";
import "./SearchForm.css";
import { useNavigate } from "react-router-dom";
import { useRepository } from "../../../../contexts/RepositoryContext";

export default function SearchForm() {
  const { searchRepositories, searchValue, setSearchValue } = useRepository();
  const navigate = useNavigate()

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchValue(e.currentTarget.value);
  };

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const form = e.currentTarget;
    const data = new FormData(form);

    const search = data.get("search");

    if (typeof search === "string") {
      searchRepositories(search, 1);
    }

    navigate("/search");
  }

  return (
    <form className="form form_search" name="search" onSubmit={handleSubmit}>
      <input
        type="text"
        name="search"
        id="search-input"
        className="form__input form__input_el_search"
        placeholder="Procure por nome"
        required
        onInvalid={(e) =>
          e.currentTarget.setCustomValidity("Por favor, o nome de um repositório")
        }
        onInput={(e) => e.currentTarget.setCustomValidity("")}
        value={searchValue}
        onChange={handleChange}
      />
    </form>
  );
}
