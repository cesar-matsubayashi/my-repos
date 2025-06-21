import "./Navigation.css";
import { NavLink } from "react-router-dom";
import SearchForm from "./SearchForm/SearchForm";

export default function Navigation() {

  return (
    <ul className="navigation">
      <li>
        <NavLink className="navigation__navlink" to="/" end>
          Inicio
        </NavLink>
      </li>
      <li>
        <NavLink className="navigation__navlink" to="/favoritos" end>
          Favoritos
        </NavLink>
      </li>
      <li>
        <NavLink className="navigation__navlink" to="/meusrepositorios" end>
          Meus Repositórios
        </NavLink>
      </li>
      <li className="navigation__search">
        <SearchForm />
      </li>
    </ul>
  );
}
