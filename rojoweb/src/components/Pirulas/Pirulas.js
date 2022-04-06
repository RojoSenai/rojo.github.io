import React,{Component} from "react";
import Blue_Pill from '../../assets/img/bluepill.png';
import Red_Pill from '../../assets/img/redpill.png';
import '../../assets/css/Login.css';



class Pirulas extends Component{

   render(){

       return (
        <div className="Pirula">
            <img className="Azul_Img" src={Blue_Pill} alt="Pirula azul no canto inferior a esquerda da tela"/>
            <img className="Vermelho_Img" src={Red_Pill} alt="Pirula vermelha no canto inferior a esquerda da tela" />
        </div>
       )
   }
}

export default Pirulas