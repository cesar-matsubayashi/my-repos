import { Outlet } from "react-router";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import { useModal } from "../../contexts/ModalContext";
import Modal from "../Modal/Modal";
import RepositoryDetails from "../RepositoryDetails/RepositoryDetails";

export default function Layout() {
  const { open, setOpen, repository } = useModal();
  
  return (
    <>
      <Header />
      <Outlet />
      <Footer />
      <Modal isOpen={open} onClose={() => setOpen(false)}>
        <RepositoryDetails />
      </Modal>
    </>
  );
}
