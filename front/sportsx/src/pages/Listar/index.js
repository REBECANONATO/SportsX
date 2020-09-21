import React from 'react';
import { useHistory } from "react-router-dom";
import api from '../../service/api';
import TableCell from '@material-ui/core/TableCell';
import TableRow from '@material-ui/core/TableRow';
import {  IconButton  }  from '@material-ui/core';
import { FiEdit3, FiDelete  } from "react-icons/fi";
import '../../global.css';
import './index.css';

function Listar({ clienteId }){
    const history = useHistory();

    async function handleDelete(id) {
        try {
            await api.post('/Clientes/Delete/'+id);
          } catch (err) {
            alert('Erro ao deletar caso, tente novamente.');
          }
    }

    async function handleEdit(id) {
        //history.push("/Editar/"+id);
    }

    function formatCnpjCpf(value) {
        const CPF_LENGTH = 11;
        if (value.length === CPF_LENGTH) {
            /* eslint-disable */
            return value.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3-\$4");
        } 
        return value.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g, "\$1.\$2.\$3/\$4-\$5");
    }

    function formatTelefone(value) {
        const CELULAR_LENGTH = 11;
        if (value.length === CELULAR_LENGTH) {
            return value.replace(/(\d{2})(\d{1})(\d{4})(\d{4})/g, "(\$1) \$2 \$3-\$4");
        } 
        return value.replace(/(\d{2})(\d{4})(\d{4})/g, "(\$1) \$2-\$3");
    }

    return (
        <TableRow key={clienteId.id}>
            <TableCell component="th" scope="row">
                <strong>{clienteId.nomeRazaoSocial}</strong> 
            </TableCell>
            <TableCell align="center">
                <span>{formatCnpjCpf(clienteId.cpfCnpj)}</span>
            </TableCell>
            <TableCell align="center">
                <span>{clienteId.cep.replace(/(\d{2})(\d{3})(\d{3})/g, "\$1.\$2-\$3")}</span>
            </TableCell>
            <TableCell align="center">
                <span>{clienteId.email}</span>
            </TableCell>
            <TableCell align="center">
                <span>{formatTelefone(clienteId.telefone)}</span>
            </TableCell>
            <TableCell align="center">
                <span>{clienteId.classificacao}</span>
            </TableCell>
            <TableCell align="center">
                <IconButton edge="end" aria-label="comments" onClick={() => handleEdit(clienteId.id)} type="button">
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