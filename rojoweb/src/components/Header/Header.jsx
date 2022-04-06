import React, { Component } from "react";
import Rojologo from '../../assets/img/Rojo_imagem.png';
import '../../assets/css/CadastroUsuarioEmpresa.css';
import { Link } from 'react-router-dom';




class Cabeca extends Component {

    //logout
    logout = () => {
        localStorage.removeItem('usuario-login');
        console.log('Você saiu');
    }



    render() {

        return (
            <div className="ContainerRojo">
                <div>
                    <img className="Rojinho" src={Rojologo} alt="Logo da empresa" />
                </div>
                <div className='ContainerLetras'>
                    <Link to="/EmpresaCor"><a href="" className="Names_a">CadastrarCor</a></Link>
                    <Link to="/CadastrarUserAdm"><a href="" className="Names_a">Cadastrar  Usuario</a></Link>
                    <Link to="/CadastrarEmpresa"><a href="" className="Names_a">Cadastrar empresa</a></Link>
                    <Link to="/CadastroEvento"><a href="" className="Names_a">Cadastrar evento</a></Link>
                    <Link to="/"><a onClick={this.logout} className="Names_a">Sair</a></Link>
                </div>
            </div>
        )
    }
}

export default Cabeca

