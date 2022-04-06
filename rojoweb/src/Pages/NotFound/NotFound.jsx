import './not.css';
import Helmet from 'react-helmet';

function NotFound() {
  return (
    <div className="App">
    <Helmet title="Projeto Rojo - NotFound" />
      <header className="App-header">
        <h1>404 Not Found</h1>
        <h1>Está página não foi encontrada</h1>
      </header>
    </div>
  );
}

export default NotFound;