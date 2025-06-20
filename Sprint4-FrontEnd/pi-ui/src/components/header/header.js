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
          <Link to="/app">Home</Link>
          <Link to="/cadastrarsala">Salas</Link>
          <Link to="/equipamento">Equipamentos</Link>
          <Link to="/cadastrarusuario">Usuários</Link>
          <button onClick={handleLogout} style={{ background: 'none', border: 'none', color: '#333', cursor: 'pointer' }}>
            <h3>Sair</h3>
          </button>
        </nav>
      </div>
    </header>
  );
}

export default Header;
