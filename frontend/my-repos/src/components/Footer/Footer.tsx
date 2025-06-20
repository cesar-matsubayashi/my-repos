import "./Footer.css";
import github from "../../images/github.svg";
import linkedin from "../../images/linkedin.svg";
import { Link } from "react-router";

export default function Footer() {
  return (
    <footer className="footer">
      <p className="footer__copyright">&copy; 2025 MyRepos, desenvolvido por Cesar Matsubayashi</p>
      <div className="footer__container">
        <ul className="footer__social-media">
          <li>
            <Link
              to="https://github.com/cesar-matsubayashi"
              target="_blank"
              rel="noopener noreferrer"
              className="footer__link"
            >
              <img src={github} alt="GitHub" className="footer__github" />
            </Link>
          </li>
          <li>
            <Link
              to="https://www.linkedin.com/in/cesar-matsubayashi-587998b5"
              target="_blank"
              rel="noopener noreferrer"
              className="footer__link"
            >
              <img src={linkedin} alt="LinkedIn" className="footer__linkedin" />
            </Link>
          </li>
        </ul>
      </div>
    </footer>
  );
}
