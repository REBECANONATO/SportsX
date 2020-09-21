import React, { useState } from "react";
import { Link, useHistory } from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";
import { makeStyles } from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import Chip from '@material-ui/core/Chip';
import AddIcon from '@material-ui/icons/Add';
import Paper from '@material-ui/core/Paper';
import IconButton from '@material-ui/core/IconButton';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import { mask as masker, unMask } from "remask";

import api from "../../service/api";
import '../../global.css';
import "./index.css";

const useStyles = makeStyles((theme) => ({
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  rootChips: {
    display: 'flex',
    justifyContent: 'center',
    flexWrap: 'wrap',
  },
  chip: {
    margin: theme.spacing(1),
  },
  root: {
    padding: '2px 4px',
    display: 'flex',
    alignItems: 'center',
    width: 400,
  },
  input: {
    marginLeft: theme.spacing(1),
    flex: 1,
  },
  iconButton: {
    padding: 10,
  },
}));

const InputMask = ({ mask, onChange, value, ...props }) => {
  const handleChange = ev => {
    const originalValue = unMask(ev.target.value);
    onChange(originalValue);
  };
  const handleValue = masker(value, mask);
  return <input {...props} onChange={handleChange} value={handleValue} />;
};

export default function Cadastrar() {
  const [nomeRazaoSocial, setNomeRazaoSocial] = useState("");
  const [cpfCnpj, setCpfCnpj] = useState("");
  const [email, setEmail] = useState("");
  const [telefone, setTelefone] = useState("");
  const [cep, setCep] = useState("");
  const [classificacaoDado, setClassificacaoDado] = useState("");
  const [phoneList, setPhoneList] = useState([]);
  const history = useHistory();
  const classes = useStyles();


  async function handleRegister(e) {
    e.preventDefault();
    let classificacao =  parseInt(classificacaoDado);
    let arrayPhoneList = phoneList.map(telefone => {return telefone.label});
    let telefone = arrayPhoneList.toString();

    const cliente = {
      nomeRazaoSocial,
      cpfCnpj,
      telefone,
      cep,
      email,
      classificacao
    };
    try {
      await api.post("/Clientes/Create", cliente);
      history.push("/");
    } catch (err) {
      alert(`Erro no cadastro: ${err}`);
    }
  }

  function telefoneSubmitHandler(e) {
    setPhoneList([
        ...phoneList, 
        { key: phoneList.length, label: telefone}
    ])
    setTelefone("")
    e.preventDefault()
}

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
          <InputMask
            placeholder="CPF/CNPJ"
            mask={["999.999.999-99", "99.999.999/9999-99"]}
            value={cpfCnpj}
            onChange={setCpfCnpj}
          />
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={e => setEmail(e.target.value)}
          />
          <div className="input-group">
            <Paper component="form" className={classes.root}>
              <InputMask
                placeholder="Telefone"
                value={telefone}
                mask={["(99) 9999-9999", "(99) 9 9999-9999"]}
                onChange={setTelefone}
              />
              <IconButton type="submit" className={classes.iconButton} onClick={telefoneSubmitHandler}>
                <AddIcon />
              </IconButton>
            </Paper>
            <div className={classes.rootChips}>
              {phoneList.map(phone => {
                  return <Chip key={phone.key} className={classes.chip} label={phone.label}/>
                })}
            </div>
          </div>
          <div className="input-group">
            <InputMask
              placeholder="Cep"
              mask={["99.999-999"]}
              value={cep}
              onChange={setCep}
            />
            <FormControl className={classes.formControl}>
              <InputLabel id="demo-simple-select-label">Classificação</InputLabel>
              <Select
                labelId="demo-simple-select-label"
                id="demo-simple-select"
                value={classificacaoDado}
                onChange={e => setClassificacaoDado(e.target.value)}
              >
                <MenuItem value={1}>Ativo</MenuItem>
                <MenuItem value={2}>Preferencial</MenuItem>
                <MenuItem value={3}>Inativo</MenuItem>
              </Select>
            </FormControl>
          </div>
          <button className="button" type="submit">
            Cadastrar
          </button>
        </form>
      </div>
    </div>
  );
}