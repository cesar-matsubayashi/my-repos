import './Main.css'
import AddForm from "./AddForm/AddForm";

export default function Main() {
  return (
    <main className="repositories">
      <section className="intro">
        <h1 className="intro__headline">
          Organize e adicione seus repositórios aqui!
        </h1>
        <p className="intro__caption">
          Gerencie facilmente seus repositórios do GitHub em um só lugar. 
          Mantenha seus favoritos por perto — 
          basta colar o link de um repositório aqui para começar.
        </p>
        <AddForm />
      </section>
    </main>
  );
}