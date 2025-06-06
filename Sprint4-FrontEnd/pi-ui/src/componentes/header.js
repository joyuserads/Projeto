
import './header.css'

function toggleDropdown() {
    const menu = document.getElementById('dropdownMenu');
    menu.style.display = menu.style.display === 'block' ? 'none' : 'block';
}

// Fecha o menu ao clicar fora
document.addEventListener('click', function (event) {
    const dropdown = document.getElementById('dropdownMenu');
    const usuario = document.querySelector('.usuario-logado');
    if (!usuario.contains(event.target)) {
        dropdown.style.display = 'none';
    }
});





function Header() {
    return (
        <div>
            <header className="cabecalho-principal">
                <div className="container">
                    <a href="/home"><img src={logo} alt="Image" height="50" width="220" /></a>
                    <nav className="cabecalhoPrincipal-nav">
                        <a href="/cadastrarsala">Salas</a>
                        <a href="/cadastrarequipamento">Equipamentos</a>
                        <a href="/cadastrarusuario">Usuários</a>
                        <a onClick={() => localStorage.removeItem('usuario-login')} href="/">Sair</a>
                    </nav>
                </div>
            </header>
        </div>
    )
}

export default Header;