import { TableDoutoresComponent } from './components/table-doutores/table-doutores.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TablePacientesComponent } from './components/table-pacientes/table-pacientes.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {path:'pacientes', component: TablePacientesComponent},
  {path:'doutores', component: TableDoutoresComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
