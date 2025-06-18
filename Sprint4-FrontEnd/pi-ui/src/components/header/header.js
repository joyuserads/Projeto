import './header.css';

function Header(){
    return(
        <div>
            <header className="cab-principal">
                <div className="container" >
                    
                    <nav className="cab-Principal-nav">
                        <a href="/cadastrarsala">Salas</a>
                        <a href="/cadastrarequipamento">Equipamentos</a>
                        <a href="/cadastrarusuario">Usuários</a>
                        <a onClick={ () => localStorage.removeItem('usuario-login')} href="/">Sair</a>
                    </nav>
                </div>
            </header>
        </div>
    )


}

export default Header;