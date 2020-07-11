import { DoutoresDTO } from './../models/doutor';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DoutoresService {

  private Api = "http://localhost:61817/api/"
  private ApiDoutores = "http://localhost:61817/api/Doutores"
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  ObterListaDoutores(){
    return this.http.get<DoutoresDTO[]>(
      this.Api.concat('Doutores')
    )
  }
  AdicionarPaciente(doutor: DoutoresDTO): Observable<DoutoresDTO>{
    return this.http.post<DoutoresDTO>(this.Api.concat('Doutores'), JSON.stringify(doutor),this.httpOptions)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
  }

  deleteDoutor(idDoutor : DoutoresDTO){
    return this.http.delete(`${this.ApiDoutores}/${idDoutor.idDoutor}`)
    .pipe(
      retry(2),
      catchError(this.handleError)
    )
    
  }

  updateDoutor(doutor : DoutoresDTO){
    return this.http.put(`${this.ApiDoutores}/${doutor.idDoutor}`,JSON.stringify(doutor), this.httpOptions)
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
    alert('Algum erro aconteceu, verifique o console do seu navegador');
    console.log(errorMessage)
    return throwError(errorMessage);
  };
}
