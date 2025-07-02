import { useState, useEffect, use } from 'react'; // Importa hooks React para estado e efeitos colaterais
import Header from '../../components/header/header';  // Importa componente Header personalizado
import axios from 'axios'; // Importa biblioteca para fazer requisições HTTP
import { Helmet } from 'react-helmet-async';  // Importa componente para gerenciar o título da página
import '../Equipamentos/equipamento.css';

function Equipamento() {
    const [idEquipamento, setIdEquipamento] = useState(0);
    const [listaEquipamentos, setListaEquipamentos] = useState([]);
    const [marca, setMarca] = useState('');
    const [tipo, setTipo] = useState('');
    const [descricao, setDescricao] = useState('');
    const [numeroPatrimonio, setNumeroPatrimonio] = useState(0);
    const [disponivel, setDisponivel] = useState(false);

    function cadastrarEquipamentos(event) {

        event.preventDefault();
        let equipamento = {
            Marca: marca,
            Descricao: descricao,
            TipoEquipamento: tipo,
            NumeroPatrimonio: numeroPatrimonio,
            Disponivel: disponivel
        };

        const head = {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type': 'application/json'
            }
        };

        if (idEquipamento !== 0) {
            // chamando put
            axios.put(`https://localhost:7260/api/Equipamento/${idEquipamento}`, equipamento, head)

                .then(resposta => {
                    if (resposta.status === 204) {
                        console.log('Equipamento Atualizado!');
                        buscarEquipamentos();
                        limparCampos();
                    }
                })
                .catch((erro) => console.log(erro));

        } else {
            console.log("Dados enviados para a API:", equipamento);
            // chamando post
            axios.post('https://localhost:7260/api/Equipamento', equipamento, head)
                .then(resposta => {
                    if (resposta.status === 201) {
                        console.log("Equipamento cadastrado com sucesso!");
                        buscarEquipamentos();
                        limparCampos();
                    }
                })
                .catch((erro) => {
                    if (erro.response) {
                        console.error("Erro 400 - Dados inválidos:", erro.response.data);
                    } else {
                        console.error("Erro:", erro.message);
                    }
                });
        }


    }

    function buscarEquipamentos() {
        axios.get('https://localhost:7260/api/Equipamento', {

            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaEquipamentos(resposta.data); // Atualiza o estado
                    console.log(resposta.data);
                }
            })
            .catch(erro => {
                console.error('Erro ao buscar equipamentos:', erro);
            });
    }

    function limparCampos() {
        setIdEquipamento(0);
        setMarca('');
        setDescricao('');
        setNumeroPatrimonio('');
        setTipo('');

    }


    useEffect(buscarEquipamentos, [])

    return (
        <div className='equipamento'>
            <Helmet>
                <title>Equipamento</title>
            </Helmet>

            <Header />

            <main>
                <section className="section1">
                    <div className="content">
                        <div className="tit-cadEquipamento" >
                            <h1>Cadastrar Equipamento</h1>
                            <hr />
                        </div>
                    </div>

                    <form onSubmit={cadastrarEquipamentos} className="form content">
                        <div className="grid_1">
                            <select
                                className="select-tipo"
                                name="TipoEquipamento"
                                value={tipo}
                                onChange={(event) => setTipo(event.target.value)}
                                required

                            >
                                <option disabled value="">Selecione o tipo de equipamento</option>
                                <option value="Informática">Informática</option>
                                <option value="Eletroeletrônica">Eletroeletrônica</option>
                                <option value="Mobiliário">Mobiliário</option>
                            </select>

                            <input type="text" value={marca} onChange={(event) => setMarca(event.target.value)} name="marca" placeholder="Marca" className="inputW" required />


                        </div>

                        <div className="grid_1">

                            <input type="text" minLength="10" name="numeroPatrimonio" value={numeroPatrimonio} placeholder="Nº de Patrimonio" onChange={(event) => setNumeroPatrimonio(event.target.value)} className="input watermark" required />

                        </div>

                        <p className="title-descricao">Descrição:</p>
                        <input type="text" value={descricao} className="descricao" onChange={(event) => setDescricao(event.target.value)} name="descricao" required />

                        <h2>Estado</h2>
                        <div className="colum">
                            <div className="comlum2">
                                <input type="radio" value={true} checked={disponivel === true} onChange={() => setDisponivel(true)} name="disponivel" id="ativo" />
                                <label htmlFor="estado">Ativo</label>
                            </div>
                            <div className="comlum2">
                                <input type="radio" value={false} checked={disponivel === false} onChange={() => setDisponivel(false)} name="disponivel" id="inativo" />
                                <label htmlFor="estado">Inativo</label>
                            </div>
                        </div>
                        <div className="grid_1" id="botao">
                            {/* Botão com classe "btn-cad" */}
                            {/* O botão fica desabilitado quando a variável 'descricao' estiver vazia */}
                            {/* disabled recebe um booleano: true se descricao for vazia, false caso contrário */}
                            <button className="btn-cad" disabled={descricao === ''} type="submit">
                                {
                                    // Se idEquipamento for zero, exibe "Cadastrar"
                                    // Caso contrário, exibe "Atualizar"
                                    idEquipamento === 0 ? 'Cadastrar' : 'Atualizar'
                                }
                            </button>
                            <button className="clean" disabled={idEquipamento === 0 ? true : false} onClick={limparCampos}>Limpar</button>
                        </div>

                    </form>

                </section>


                <section>
                    <div className="lista">
                        <div className="content">
                            <div className="title-cadEquipamento">

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
                </section>
            </main>
        </div>
    )


}










export default Equipamento;