import React,{Component} from "react";
import Rojologo from '../../assets/img/Rojo_imagem.png';
import LetraRojo from '../../assets/img/letter.svg';
import '../../assets/css/Login.css';



class Titulo extends Component{

   render(){

       return (
        <div className="ContainerLogo">
            <img className="Rojo" src={Rojologo} alt="Logo da empresa"/>
            <img className="Letra-logo" src={LetraRojo} alt="Letra giratoria em volta do logo" />
        </div>
       )
   }
}

export default Titulo