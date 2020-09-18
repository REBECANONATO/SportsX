import React from 'react';
import api from '../service/api';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import {  IconButton  }  from '@material-ui/core';
import { Edit, Delete } from '@material-ui/icons';
import './index.css';

function Listar({ clienteId }){
    // const { clienteId, ...rest } = props;

    async function handleDelete(id) {
        console.log(id);
        try {
            await api.post('/Clientes/Delete/'+id);
            //setIncidents(incidents.filter(incident => incident.id !== id));
          } catch (err) {
            alert('Erro ao deletar caso, tente novamente.');
          }
    }

    return (
        <TableRow key={clienteId.id}>
            <TableCell component="th" scope="row">
                <strong>{clienteId.nomeRazaoSocial}</strong> 
            </TableCell>
            <TableCell align="right">
                <span>{clienteId.cpfCnpj}</span>
            </TableCell>
            <TableCell align="right">
                <span>{clienteId.cep}</span>
            </TableCell>
            <TableCell align="right">
                <span>{clienteId.email}</span>
            </TableCell>
            <TableCell align="right">
                <span>{clienteId.telefone}</span>
            </TableCell>
            <TableCell align="right">
                <span>{clienteId.classificacao}</span>
            </TableCell>
            <TableCell align="right">
                <IconButton edge="end" aria-label="comments" >
                        <Edit />
                </IconButton>

                <IconButton edge="end" aria-label="comments" onClick={() => handleDelete(clienteId.id)} type="button">
                    <Delete color="action" />
                </IconButton>
            </TableCell>
        </TableRow>
    );
}

export default Listar;