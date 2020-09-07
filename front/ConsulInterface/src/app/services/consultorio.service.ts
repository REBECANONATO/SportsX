import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Consultorio } from '../models/consultorio';

@Injectable({
  providedIn: 'root'
})
export class ConsultorioService {

  url = 'https://localhost:44381/Consultorios'; // api rest fake

  // injetando o HttpClient
  constructor(private httpClient: HttpClient) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os consultorios
  getConsultorios(): Observable<Consultorio[]> {
    return this.httpClient.get<Consultorio[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem um consultorio pelo id
  getConsultorioById(id: number): Observable<Consultorio> {
    return this.httpClient.get<Consultorio>(this.url + '/Details/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva um consultorio
  saveConsultorio(consultorio: Consultorio): Observable<Consultorio> {
    return this.httpClient.post<Consultorio>(this.url + '/Create', JSON.stringify(consultorio), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza um consultorio
  updateConsultorio(consultorio: Consultorio): Observable<Consultorio> {
    return this.httpClient.post<Consultorio>(this.url + '/Edit/' + consultorio.id, JSON.stringify(consultorio), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta um consultorio
  deleteConsultorio(consultorio: Consultorio) {
    return this.httpClient.post<Consultorio>(this.url + '/Delete/' + consultorio.id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}