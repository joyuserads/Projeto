import { useState, useEffect, use } from 'react'; // Importa hooks React para estado e efeitos colaterais
import Header from '../../components/header/header';  // Importa componente Header personalizado
import axios from 'axios'; // Importa biblioteca para fazer requisições HTTP
import { Helmet } from 'react-helmet-async';  // Importa componente para gerenciar o título da página

function Equipamento() {
    const [idEquipamento, setIdEquipamento] = useState(0)
    const [listaEquipamentos, setListaEquipamentos] = useState([])
    const [marca, setMarca] = useState('')
    const [tipo, setTipo] = useState('')
    const [descricao, setDescricao] = useState('')
    const [numeroPatrimonio, setNumeroPatrimonio] = useState(0)
    const [disponivel, setDisponivel] = useState(false)

    function buscarEquipamentos() {
        axios.get('https://localhost:7260/api/Equipamento', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(listaEquipamentos)
                }
            })
            .catch(erro => {
                console.log(erro)
            })
    }

    function limparCampos() {
        setIdEquipamento(0)
        setMarca('')
        setDescricao('')
        setNumeroPatrimonio(0)
        setTipo('')
    }

    function cadastrarEquipamentos(event) {
        if (idEquipamento !== 0) {
            let equipamentos = {
                marca: marca,
                descricao: descricao,
                tipo: tipo,
                numeroPatrimonio: numeroPatrimonio,
                disponivel: disponivel
            }
            axios.put('https://localhost:7260/api/Equipamento/' + idEquipamento, equipamentos, {
                headers: {
                    'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.data === 204) {
                        console.log('Equipamento Atualizado!')
                        buscarEquipamentos()
                        limparCampos()
                        event.preventDeafult()
                    }
                })
                .catch((erro) => console.log(erro))

        } else {
            event.preventDeafult();
            let cadastro = {
                marca: marca,
                descricao: descricao,
                tipo: tipo,
                numeroPatrimonio: numeroPatrimonio,
                disponivel: disponivel
            }


            axios.post('https://localhost:7260/api/Equipamento', cadastro, {
                headers: {
                    'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.status === 201) {
                        console.log("Equipamento Cadastrado com sucesso!")
                        buscarEquipamentos()
                        limparCampos()
                    }
                })
                .catch(erro => {
                    console.log(erro)
                })
        }
    }

    function buscarIdEquipamentos(equipamento) {
        setMarca(equipamento.marca)
        setTipo(equipamento.tipo)
        setNumeroPatrimonio(equipamento.numeroPatrimonio)
        setDescricao(equipamento.descricao)
        setIdEquipamento(equipamento.idEquipamento)
        console.log('O Equipamento ' + equipamento.idEquipamento + ' foi selecionado; O idEquipamentoAlterado agora é: ' + equipamento.idEquipamento)
    }

    function excluirEquipamento(equipamento) {
        axios.delete('http://localhost:7260/api/Equipamento' + equipamento.idEquipamento)
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log("O equipamento " + equipamento.idEquipamento + "foi excluido")
                    buscarEquipamentos()
                }
            })
            .catch(erro => console.log(erro))
    }

    useEffect(buscarEquipamentos, [])

    return (
        <div>
            <Helmet>
                <title>
                    Equipamentos
                </title>
            </Helmet>
            <Header />

            <main>
                <section className="section1">
                    <div className="content">
                        <div className="tit.cadEquipamento">
                            <h1>Cadastrar Equipamentos</h1>
                            <hr />
                        </div>
                    </div>

                    <form onSubmit={cadastrarEquipamentos} className="form content" >
                        <div className="grid_1">
                            <select className="select-tipo" name="tipo" value={tipo} onChange={(event) => setTipo(event.target.value)} required>
                                <option disabled value="0">Selecione o tipo de equipamento</option>
                                <option value="Informática">Informática</option>
                                <option value="Eletroeletrônica">Eletroeletrônica</option>
                                <option value="Mobiliário">Mobiliário</option>
                            </select>
                            <input type="text" value={marca} onChange={(event) => setMarca(event.target.value)} name="marca" placeholder="Marca" class="input watermark" required />
                        </div>


                        <div className="grid_1">

                            <input type="number" minLength="10" name="numeroPatrimonio" value={numeroPatrimonio} placeholder="Nº de Patrimonio" onChange={(event) => setNumeroPatrimonio(event.target.value)} class="input watermark" required />

                        </div>
                         <p className="title-descricao">Descrição:</p>
                        <input type="text" value={descricao} className="descricao" onChange={(event) => setDescricao(event.target.value)} name="descricao" required/>

                         <h2>Estado</h2>

                         <div className="coluna">
                            <div className="coluna2">
                                <input type="checkbox" value={true} onChange={(event) => setDisponivel (event.target.value)} name="disponivel" id="estado" /> 
                                 <label for="estado">Ativo</label>
                            </div>
                             <div className="coluna2">
                                <input type="checkbox" value={false} onChange={(event) => setDisponivel (event.target.value)} name="disponivel" id="estado" /> 
                                 <label for="estado">Inativo</label>
                            </div>

                         </div>
                    </form>
                </section>
            </main>
        </div>
    )

}



export default Equipamento;