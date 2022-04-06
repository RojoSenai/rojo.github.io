import '../../assets/css/CadastrarEmpresa.css';
import { useState, useEffect } from 'react';
import axios from 'axios';
import { parseJwt } from '../../Services/auth';
import Logo from '../../components/Logo/Logo.js';
import Cima from '../../components/Header/Header.jsx';
import Pirulas from '../../components/Pirulas/Pirulas.js';
import Helmet from 'react-helmet';

export default function Login() {

  //States
  const [nome, setNome] = useState('');
  const [email, setCnpj] = useState('');
  const [senha, setSenha] = useState('');
  const [IdEmpresa, setIdEmpresa] = useState([]);
//const [MensagemErro, SetMensagemErro] = useState('');
  const [isLoding, setIsLoding] = useState(false);

  function FazerCadastro(event) {

    setIsLoding(true)

    //tirando função padrão da página
    event.preventDefault();

    //chamando api
    let UserAdm = {
      nome : nome,
      email: email,
      senha: senha,
      IdEmpresa: IdEmpresa,
    };
    
    
    axios.post('http://localhost:5000/api/Usuarios', UserAdm, {
      headers: {
        'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
      }
      
    })

      .then((resposta) => {

        //adicionando token no local Storage
        if (resposta.status === 200) {

          //adicionando token no localStorage do navegador
          console.log('Usuario Cadastrado')
          setNome('')
          setSenha('')
          setIdEmpresa([])
          setIsLoding(false)
          // // Redirecionamento conforme o tipo do usuário.
          // if(parseJwt().role === '1'){ // 1 é administrador geral
          //     navigate("/")
          // }else if (parseJwt().role === '3'){ //3 administrador empresa
          //     navigate("/")
        }

      }
      )

      .catch(erro => console.log(erro))
  }

  return (
    <div>
      <Helmet title="Projeto Rojo - Cadastro Usuario ADM" />
      <main className='mano'>
        <div className="cima">
        <Cima />
          <Logo />
        </div>

        <form onSubmit={FazerCadastro} action="" className="cadastrar_usu">

          <input
            className="Name_Adm"
            placeholder="Nome:"
            type="text"
            onChange={(event) => setNome(event.target.value)}
            name="nome"
            id="cadastar__Nome" />


          <input
            className="Name_Adm"
            placeholder="CNPJ:"
            type="text"
            onChange={(event) => setCnpj(event.target.value)}
            name="Cnpj"
            id="cadastar__Cnpj" />

          <input
            className="Name_Adm"
            placeholder="Senha:"
            type="password"
            onChange={(event) => setSenha(event.target.value)}
            name="Senha"
            id="cadastar__Senha" />

        <button className='BotãoCadastrarEmpresa' type="submit">Cadastrar</button>
      </form>
      {/* <div className='Div_Matrix'>
        <h2 className='CorAzul'>FAÇA SUA ESCOLHA</h2>
        <h2 className='CorVermelha'>, SAIA DA MATRIX</h2>
      </div>
      <Pirulas /> */}
    </main>
    </div >
  );
}
