import "../../../styles/Form.css";
import "./AddForm.css";
import { useState } from "react";
import { useRepository } from "../../../contexts/RepositoryContext";

export default function AddForm() {
  const { addRepository } = useRepository();
  const [inputValue, setInputValue] = useState<string>("");

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setInputValue(e.currentTarget.value);
  };

  function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();

    const form = e.currentTarget;
    const data = new FormData(form);

    const repositoryUrl = data.get("repositoryUrl");

    if (typeof repositoryUrl === "string") {
      addRepository(repositoryUrl);
    }
  }

  return (
    <form className="form form_repository" name="repository" onSubmit={handleSubmit}>
      <input
        type="text"
        name="repositoryUrl"
        id="repositoryUrl-input"
        className="form__input form__input_el_repositoryUrl"
        placeholder="Insira a url de um repositório"
        required
        onInvalid={(e) =>
          e.currentTarget.setCustomValidity("Por favor, insira a url de um repositório")
        }
        onInput={(e) => e.currentTarget.setCustomValidity("")}
        value={inputValue}
        onChange={handleChange}
      />
      <button type="submit" name="submit" className="form__button">
        Adicionar
      </button>
    </form>
  );
}
