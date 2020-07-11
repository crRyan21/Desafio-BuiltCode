import { DoutoresService } from './../../services/doutores.service';
import { DoutoresDTO } from './../../models/doutor';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-table-doutores',
  templateUrl: './table-doutores.component.html',
  styleUrls: ['./table-doutores.component.scss']
})
export class TableDoutoresComponent implements OnInit {

  doutores: DoutoresDTO[];
  doutor = {} as DoutoresDTO;
  aba: string;


  constructor(private service: DoutoresService) { }

  ngOnInit(): void {
    this.service.ObterListaDoutores().subscribe(
      data => this.doutores = data
    )
  }
  getDoutores(){
    this.service.ObterListaDoutores().subscribe(
      data => this.doutores = data
    )
  }
  saveDoutor(form: NgForm){
    this.service.AdicionarPaciente(this.doutor).subscribe(()=>{
      this.cleanForm(form)
    })
  }

  updateDoutor(form: NgForm){
    this.service.updateDoutor(this.doutor).subscribe(() => {
      this.cleanForm(form);
    });
  }

  deleteDoutor(paciente : DoutoresDTO){
    this.service.deleteDoutor(paciente).subscribe(()=>{
      this.getDoutores()
    })
  }

  cleanForm(form: NgForm) {
    this.getDoutores();
    form.resetForm();
    this.doutor = {} as DoutoresDTO;
  }

}
