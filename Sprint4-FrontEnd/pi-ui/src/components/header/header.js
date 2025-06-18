import './header.css';
import { Link, useNavigate } from 'react-router-dom';

function Header() {
  const navigate = useNavigate();

  function handleLogout() {
    localStorage.removeItem('usuario-login');
    navigate('/'); // redireciona para a tela de login sem recarregar a página
  }

  return (
    <header className="cab-principal">
      <div className="container">
        <nav className="cab-Principal-nav">
          <Link to="/cadastrarsala">Salas</Link>
          <Link to="/cadastrarequipamento">Equipamentos</Link>
          <Link to="/cadastrarusuario">Usuários</Link>
          <button onClick={handleLogout} style={{ background: 'none', border: 'none', color: '#333', cursor: 'pointer' }}>
            Sair
          </button>
        </nav>
      </div>
    </header>
  );
}

export default Header;
