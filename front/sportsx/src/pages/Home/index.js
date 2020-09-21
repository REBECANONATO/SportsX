import React, { useState, useEffect }  from 'react';
import { Link } from "react-router-dom";
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import api from '../../service/api';
import Listar from '../Listar';
import '../../global.css';
import './index.css';

const useStyles = makeStyles({
  table: {
    minWidth: 700,
  },
});

function Home() {
  const [clientes, setClientes] = useState([]);
  const classes = useStyles();
  const [results, setResults] = useState([]);

  useEffect(() => {
    async function loadClientes(){
      var response = await api.get('/Clientes');
      setResults(response.data);
      setClientes(response.data);
    };
    
    loadClientes();
  }, []);

  var filtro = document.getElementById('filtro-pesquisa');
  if(filtro !== null){
    filtro.onkeyup = function() {
      var nomeFiltro = filtro.value.toLowerCase().trim();
      let clienteAux = [];
      results.forEach( x => {
        var cliente = x.nomeRazaoSocial;
        if(cliente.toLowerCase().indexOf(nomeFiltro) >= 0 && nomeFiltro !== ""){
          clienteAux.push(x);
        }
      });
      setClientes(clienteAux);
    };
  }

  return (
    <div id="app">
      <header className="contentMenu">
        <nav className="navbar">
          <strong className="navbar__logo">Teste Técnico</strong>
          <h3 className="navbar__logo">Controle Clientes SportsX</h3>

          <Link className="button navbar__logo" type="submit" to="/cadastrar">
            Cadastrar Novo Cliente
          </Link>

          <ul className="navbar__menu">
            <input id="filtro-pesquisa" className="button--sign-up" placeholder="Pesquisar"/>
          </ul>
        </nav>
      </header>

      <main>
        <TableContainer component={Paper}>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Nome / Razão Social</TableCell>
                <TableCell align="center">CPF / CNPJ</TableCell>
                <TableCell align="center">CEP</TableCell>
                <TableCell align="center">E-mail</TableCell>
                <TableCell align="center">Telefone</TableCell>
                <TableCell align="center">Classificação</TableCell>
                <TableCell align="center">Ações</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {clientes.map(cliente => (
                <Listar key={cliente.id} clienteId={cliente} />
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </main>
    </div>
  );
}

export default Home;
