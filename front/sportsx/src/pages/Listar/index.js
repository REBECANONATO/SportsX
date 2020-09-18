import React from 'react';
import api from '../../service/api';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import {  IconButton  }  from '@material-ui/core';
import { FiEdit3, FiDelete  } from "react-icons/fi";
import './index.css';

function Listar({ clienteId }){
    async function handleDelete(id) {
        console.log(id);
        try {
            await api.post('/Clientes/Delete/'+id);
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
                        <FiEdit3 />
                </IconButton>

                <IconButton edge="end" aria-label="comments" onClick={() => handleDelete(clienteId.id)} type="button">
                    <FiDelete color="action" />
                </IconButton>
            </TableCell>
        </TableRow>
    );
}

export default Listar;