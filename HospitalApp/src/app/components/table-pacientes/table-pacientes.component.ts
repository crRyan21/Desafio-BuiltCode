import { Component, OnInit } from '@angular/core';
import { PacienteService} from './../../services/paciente.service';
import { PacientesDTO } from './../../models/pacient';
import { FormGroup, NgForm } from '@angular/forms';

@Component({
  selector: 'app-table-pacientes',
  templateUrl: './table-pacientes.component.html',
  styleUrls: ['./table-pacientes.component.scss']
})
export class TablePacientesComponent implements OnInit {

  pacientes: any[];
  paciente = {} as PacientesDTO;
  aba: any;

  constructor(private service: PacienteService) { }

  ngOnInit(): void {
    this.service.ObterListaPacientes().subscribe(
      data => this.pacientes = data
    )
  }

  getPacientes(){
    this.service.ObterListaPacientes().subscribe(
      data => this.pacientes = data
    )
  }

  savePaciente(form: NgForm){
    this.service.AdicionarPaciente(this.paciente).subscribe(()=>{
      this.cleanForm(form)
    })
  }
  deletePaciente(paciente : PacientesDTO){
    this.service.deletePaciente(paciente).subscribe(()=>{
      this.getPacientes()
    })
  }
  
  updatePaciente(form: NgForm){
    this.service.AtualizarPaciente(this.paciente).subscribe(() => {
      this.cleanForm(form);
    });
  }

  cleanForm(form: NgForm) {
    this.getPacientes();
    form.resetForm();
    this.paciente = {} as PacientesDTO;
  }

}
