import { PacientesDTO } from './../models/pacient';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  private Api = "http://localhost:61817/api/"
  private ApiPacientes = "http://localhost:61817/api/Pacientes"
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  ObterListaPacientes(){
    return this.http.get<PacientesDTO[]>(
      this.Api.concat('Pacientes')
    )
  }
  AdicionarPaciente(paciente: PacientesDTO): Observable<PacientesDTO>{
    return this.http.post<PacientesDTO>(this.Api.concat('Pacientes'), JSON.stringify(paciente),this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }
  // AtualizaPaciente(paciente: PacientesDTO):Observable<PacientesDTO>{
  //   return this.http.put<PacientesDTO>(this.Api.concat('Pacientes' + paciente.idPaciente,))
  // }

  deletePaciente(idPaciente : PacientesDTO){
    return this.http.delete(`${this.ApiPacientes}/${idPaciente.idPaciente}`).pipe(take(1));
  }

 
  AtualizarPaciente(paciente : PacientesDTO){
    return this.http.put(`${this.ApiPacientes}/${paciente.idPaciente}`,JSON.stringify(paciente), this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
    
  }

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
