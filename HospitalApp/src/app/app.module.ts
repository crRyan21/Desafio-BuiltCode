import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { TablePacientesComponent } from './components/table-pacientes/table-pacientes.component';
import { PacienteService } from './services/paciente.service';
import { TableDoutoresComponent } from './components/table-doutores/table-doutores.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    TablePacientesComponent,
    TableDoutoresComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [
    PacienteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
