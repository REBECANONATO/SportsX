import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './pages/home/home.component';
import { ConsultorioComponent } from './pages/consultorio/consultorio.component';
import { Error404Component } from './pages/error404/error404.component';
import { MedicoComponent } from './pages/medico/medico.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ConsultorioComponent,
    Error404Component,
    MedicoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }