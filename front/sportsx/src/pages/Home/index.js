import React, { useState, useEffect }  from 'react';
import { Link, useHistory } from "react-router-dom";
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

  useEffect(() => {
    async function loadClientes(){
      const response = await api.get('/Clientes');
      setClientes(response.data);
    };


    loadClientes();
  }, []);

  return (
    <div id="app">
      <header>
        <strong>Teste Técnico</strong>
        <h3>Controle Clientes SportsX</h3>

        <Link className="button" type="submit" to="/cadastrar">
          Cadastrar Novo Cliente
        </Link>
      </header>
      <br />
      <hr />
      <br />
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
