import '../../assets/css/CadastroEvento.css';
import { useState, useEffect } from 'react';
import Cima from '../../components/Header/Header.jsx';
import axios from 'axios';
import Logo from '../../components/Logo/Logo.js';
import Helmet from 'react-helmet';


export default function Login() {

  //States
  const [nome, setNome] = useState('');
  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');
  const [Image, setImage] = useState('');
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
      <Helmet title="Projeto Rojo - Cadastro Usuario Empresa" />
     <main className='mano'>
        <div className="cima">
        <Cima />
          <Logo />
        </div>

        <form onSubmit={FazerCadastro} action="" className="cadastrar_evt">

          <input
            className="Name_Event"
            placeholder="Nome do Evento:"
            type="text"
            onChange={(event) => setNome(event.target.value)}
            name="nome"
            id="Adm__nome" />


          <input
            className="Name_Event"
            placeholder="Descrição:"
            type="text"
            onChange={(event) => setEmail(event.target.value)}
            name="Decrição"
            id="login__email" />

          <input
            className="Name_Event"
            placeholder="Nome do Palestrante:"
            type="text"
            onChange={(event) => setSenha(event.target.value)}
            name="Nome_Palestrante"
            id="login__senha" />
            
            <input
            className="Name_Event"
            placeholder="Incio do Evento:"
            type="date"
            onChange={(event) => setSenha(event.target.value)}
            name="Comeco_evento"
            id="login__senha" />

          <input
            className="Name_Event"
            placeholder="Fim do Evento:"
            type="date"
            onChange={(event) => setSenha(event.target.value)}
            name="Fim_evento"
            id="login__senha" />
          
          <div>
            <label className="event_file" for="Imagem">Escolha o arquivo:</label>
          <input
            className="Name_Event_img"
            placeholder="Imagem do Evento:"
            type="file"
            onChange={(event) => setImage(event.target.value)}
            name="imagem"
            id="Imagem"/>
            </div>


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
