import { useState, useEffect } from 'react'; // Importa hooks React para estado e efeitos colaterais
import './App.css';
import Header from '../../components/header/header';  // Importa componente Header personalizado
import axios from 'axios'; // Importa biblioteca para fazer requisições HTTP
import { Helmet } from 'react-helmet-async';  // Importa componente para gerenciar o título da página



function App() {

  // Cria estado para armazenar lista de salas e equipamentos inicialmente vazio
  const [listaSalas, setListaSalas] = useState([])
  const [listaEquipamentos, setListaEquipamentos] = useState([])

  // Função que busca lista de salas na API
  function buscarSalas() {
    axios.get('https://localhost:7260/api/Sala', {  // Faz GET para endpoint de salas
      headers: {
        // Passa token de autenticação no cabeçalho Authorization com Bearer
        'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
      }
    })

      .then(resposta => {
        if (resposta.status === 200) {  // Se a resposta for sucesso
          setListaSalas(resposta.data) // Atualiza o estado com os equipamentos
          console.log('Listando Salas') // Log para confirmar busca
        }
      })
      .catch((erro) => console.log(erro)) // Log de erro caso a requisição falhe

  }

  function buscarEquipamentos() {
    axios.get('https://localhost:7260/api/Equipamento', {
      headers: {
        'Authorization': 'Bearer' + localStorage.getItem('usuario-login')

      }
    })
      .then(resposta => {
        if (resposta.status === 200) {
          setListaEquipamentos(resposta.data)
          console.log('Listando Equipamentos!')
        }
      })
      .catch((erro) => console.log(erro))
  }

  // useEffect executa função buscarSalas quando o componente é montado ([] = só uma vez)

  useEffect(() => {
    buscarSalas();
  }, []); // Passando a função dentro de useEffect /w [] garante que roda só na montagem

  useEffect(() => {
    buscarEquipamentos();
  }, []); // [] garante que roda só na montagem


  return (
    <div className="App">

      <Helmet>
        <title>SM - Home</title>
      </Helmet>
      <Header />

      <section className="listagem">
        <div className="lista">
          <div className="content">
            <div className="tit-cadEquipamento">
              <br />
              <br />
              <br />
              <br />
              <h1>Lista de Equipamentos</h1>
              <hr />
            </div>
          </div>
        </div>


        <section className="Tabela">
          <table>
            <thead>
              <tr>
                <th className="th-h">Marca</th>
                <th className="th-h">Tipo</th>
                <th className="th-h">Descrição</th>
                <th className="th-h">Numero de Patrimonio</th>
              </tr>
            </thead>

            <tbody>
              {
                listaEquipamentos.map(equipamento => {
                  return (
                    <tr key={equipamento.idEquipamento}>
                      <th> {equipamento.marca} </th>
                      <th> {equipamento.tipoEquipamento}</th>
                      <th>{equipamento.descricao}</th>
                      <th>{equipamento.numeroPatrimonio}</th>
                      <th>{
                        equipamento.disponivel ? "Ativo" : "Inativo"
                      }
                      </th>
                    </tr>
                  )
                })
              }
            </tbody>

          </table>
        </section>
        <div className="list">
          <div className="content">
            <div className="tit-cadEquipamento">
              <br />
              <br />
              <h1>Lista de Salas</h1>
              <hr />
            </div>
          </div>
              <section className="Tabela">
              <table>
                <thead>
                  <tr>
                    <th className="th-h">Sala</th>
                    <th className="th-h">Andar</th>
                    <th className="th-h">Metragem</th>
                  </tr>
                </thead>

                <tbody>
                  {
                    listaSalas.map(sala => {
                      return(
                        <tr key={sala.idSala}>
                          <th>{sala.andar}</th>
                          <th>{sala.nome}</th>
                          <th>{sala.metragem}</th>
                        </tr>
                        
                      )
                    })
                  }
                </tbody>
              </table>
              </section>

        </div>

      </section>

    </div>



  );
}

export default App;
