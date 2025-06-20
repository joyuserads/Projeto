import { useState } from 'react';
import axios from 'axios';
import { parseJwt } from '../../services/auth';
import { useNavigate } from 'react-router-dom'; // <-- atualizado
import './login.css';
import { Helmet } from 'react-helmet-async';

function Login() {
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const navigate = useNavigate(); // <-- atualizado

  function efetuaLogin(event) {
    event.preventDefault();
    axios
      .post('https://localhost:7260/api/Usuario', {
        email: email,
        senha: senha,
      })
       .then(resposta => {
            if(resposta.status === 200){
                localStorage.setItem("usuario-login", resposta.data.token)
                console.log('Token : '+ resposta.data.token)
                console.log(parseJwt())

                if(parseJwt().role === "1"){
                    navigate('/equipamento')
                } else if(parseJwt().role === "2"){
                    navigate('/app')
                }

                
               
            }
        })
        .catch(erro => {
            console.log(erro)
        })
      /*.then((resposta) => {
    console.log('Resposta recebida:', resposta);
  })
  .catch((erro) => {
    console.error('Erro ao fazer login:', erro.message);
    if (erro.response) {
      console.log('Status:', erro.response.status);
      console.log('Data:', erro.response.data);
    } else if (erro.request) {
      console.log('Erro na requisição: Sem resposta da API');
    } else {
      console.log('Erro ao configurar a requisição:', erro.message);
    }
  }); */
  }
   
  

  return (
    <div className="bodyLgn">
      <Helmet>
        <title>SM - Login</title>
      </Helmet>

      <main>
        <section className="login ">
           <h3 className="animado">Andreozzis</h3>
          <h1>LOGIN</h1>
          <form onSubmit={efetuaLogin} className="form">
            <div className="item">
              <input
                className="inputLogin"
                placeholder="Email"
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>

            <div className="item">
              <input
                className="inputLogin"
                placeholder="Senha"
                type="password"
                value={senha}
                onChange={(e) => setSenha(e.target.value)}
              />
            </div>

            <div className="item">
              <button className="btn_login" id="btnLogin" type="submit">
                
                Login
              </button>
            </div>
          </form>
        </section>
      </main>
    </div>
  );
}

export default Login;
