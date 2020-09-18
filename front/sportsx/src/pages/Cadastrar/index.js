import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";
import api from "../../service/api";
import { cpfMask } from './mask'

import "./index.css";

export default function Cadastrar() {

    const history = useHistory();
    const [nomeRazaoSocial, setNomeRazaoSocial] = useState("");
    const [cpfCnpj, setCpfCnpj] = useState("");
    const [email, setEmail] = useState("");
    const [telefone, setTelefone] = useState("");
    const [cep, setCep] = useState("");
    const [classificacao, setClassificacao] = useState("");

    async function handleRegister(e) {
        e.preventDefault();
    
        const cliente = {
          nomeRazaoSocial,
          cpfCnpj,
          telefone,
          cep,
          email,
          classificacao
        };
        try {
            console.log(cliente);
            const response = await api.post("/Clientes/Create", cliente);
      
            alert(`Seu ID de acesso: ${response.data.id}`);
            history.push("/");
          } catch (err) {
            alert(`Erro no cadastro: ${err}`);
          }
    }

    // async function handlechange(e) {
    //     this.setState({ documentId: cpfMask(e.target.value) });
    // }

    return (
        <div className="register-container">
          <div className="content">
            <section>
              <h1> Cadastro</h1>
              <Link className="back-link" to="/">
                <FiArrowLeft size={16} color="#E02041" />
                Voltar para o listagem
              </Link>
            </section>
            <form onSubmit={handleRegister}>
              <input
                placeholder="Nome/Razão Social"
                value={nomeRazaoSocial}
                onChange={e => setNomeRazaoSocial(e.target.value)}
              />
               <input
                maxLength='14'
                placeholder="CPF/CNPJ"
                value={cpfCnpj}
                
                onChange={e => setCpfCnpj(e.target.value)}
              />
              <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={e => setEmail(e.target.value)}
              />
              <input
                placeholder="Telefone"
                value={telefone}
                onChange={e => setTelefone(e.target.value)}
              />
              <div className="input-group">
                <input
                  placeholder="Cep"
                  value={cep}
                  onChange={e => setCep(e.target.value)}
                />
                <input
                  type="number"
                  placeholder="Classificacao"
                  style={{ width: 80 }}
                  value={classificacao}
                  onChange={e => setClassificacao(e.target.value)}
                />
              </div>
              <button className="button" type="submit">
                Cadastrar
              </button>
            </form>
          </div>
        </div>
      );
}