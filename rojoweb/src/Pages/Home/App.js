import '../../assets/css/Login.css';
import { useState, useEffect} from 'react';
import { useNavigate } from "react-router-dom";
import axios from 'axios';
import { parseJwt } from '../../Services/auth';
import Logo from '../../components/Logo/Logo.js';
import Pirulas from '../../components/Pirulas/Pirulas.js';
import Helmet from 'react-helmet';




export default function Login() {

  //States
  const [email, setEmail] = useState('drogasil@drogasil.com');
  const [senha, setSenha] = useState('12345678');
  const [MensagemErro, SetMensagemErro] = useState('');
  const [isLoding, setIsLoding] = useState(false); 
  let navigate = useNavigate();

  function FazerLogin(event){

    setIsLoding(true)

      //tirando função padrão da página
      event.preventDefault();

      //chamando api
      axios.post('http://localhost:5000/api/Login', {
          email: email,
          senha: senha
      })

      .then( (resposta) => {

          //adicionando token no local Storage
          if(resposta.status === 200){

              //adicionando token no localStorage do navegador
              localStorage.setItem('usuario-login', resposta.data.token);
              setIsLoding(false);
              console.log(parseJwt().role);
              
              
              // // Redirecionamento conforme o tipo do usuário.
              //if(parseJwt().role === '1'){ // 1 é administrador geral
                   navigate("/EmpresaCor")
              //}else if (parseJwt().role === '3'){ //3 administrador empresa
                   navigate("/")
          }

      }
      )

      .catch(erro => console.log(erro))
  }

  return (
    <div>
      <Helmet title="Projeto Rojo - Login" />
      <main className='mano'>
        <div className="cima">
          <Logo />
        </div>

        <form onSubmit = {FazerLogin} action="" className="login">

          <input
            className="LOGIN_log"
            placeholder="Email:"
            type="text"
            onChange={(event) => setEmail(event.target.value)}
            name="Email"
            id="login__email" />

          <input
            className="LOGIN_log"
            placeholder="Senha:"
            type="password"
            onChange={(event) => setSenha(event.target.value)}
            name="Senha"
            id="login__senha" />

           <button className='BotãoLogin' type="submit">Login</button>
        </form>
        <div className='Div_Matrix'>
          <h2 className='CorAzul'>FAÇA SUA ESCOLHA</h2>
          <h2 className='CorVermelha'>, SAIA DA MATRIX</h2>
        </div>
          <Pirulas />
      </main>
    </div>
  );
}
