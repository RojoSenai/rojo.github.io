import '../../assets/css/CadastroUsuario.css';
import { useState, useEffect } from 'react';
import axios from 'axios';
import Cima from '../../components/Header/Header.jsx';
import { parseJwt } from '../../Services/auth';
import Logo from '../../components/Logo/Logo.js';

import Pirulas from '../../components/Pirulas/Pirulas.js';
import Helmet from 'react-helmet';

export default function Login() {

  //States
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
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
          setEmail('')
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
            id="Adm__nome" />


          <input
            className="Name_Adm"
            placeholder="Email:"
            type="text"
            onChange={(event) => setEmail(event.target.value)}
            name="Email"
            id="login__email" />

          <input
            className="Name_Adm"
            placeholder="Senha:"
            type="password"
            onChange={(event) => setSenha(event.target.value)}
            name="Senha"
            id="login__senha" />

          <select className="Name_Adm"  value onChange name="IdEmpresa" id="">
            <option value="" disabled selected>Empresa</option>
            <option value="empr" >Drogasil</option>
          </select>

        <button className='BotãoCadastrarUsu' type="submit">Cadastrar</button>
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
