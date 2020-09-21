import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";

import Home from "./pages/Home";
import Cadastrar from "./pages/Cadastrar";

export default function Routes() {
    return (
      <BrowserRouter>
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/Editar/:id" exact component={Cadastrar} />
          <Route path="/cadastrar" exact component={Cadastrar} />
        </Switch>
    </BrowserRouter>
  );
}