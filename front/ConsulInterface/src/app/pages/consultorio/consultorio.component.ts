import { Component, OnInit } from '@angular/core';
import { ConsultorioService } from '../../services/consultorio.service';
import { Consultorio } from '../../models/consultorio';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-consultorio',
  templateUrl: './consultorio.component.html',
  styleUrls: ['./consultorio.component.css']
})
export class ConsultorioComponent implements OnInit {

  consultorio = {} as Consultorio;
  consultorios: Consultorio[];

  constructor(private consultorioService: ConsultorioService) {}
  
  ngOnInit() {
    this.getConsultorios();
  }

  // defini se um consultorio será criado ou atualizado
  saveConsultorio(form: NgForm) {
    if (this.consultorio.id !== undefined) {
      this.consultorioService.updateConsultorio(this.consultorio).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.consultorioService.saveConsultorio(this.consultorio).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  // Chama o serviço para obtém todos os consultorios
  getConsultorios() {
    this.consultorioService.getConsultorios().subscribe((consultorios: Consultorio[]) => {
      this.consultorios = consultorios;
    });
  }

  // deleta um consultorioro
  deleteConsultorio(consultorio: Consultorio) {
    this.consultorioService.deleteConsultorio(consultorio).subscribe(() => {
      this.getConsultorios();
    });
  }

  // copia o consultorioro para ser editado.
  editConsultorio(consultorio: Consultorio) {
    this.consultorio = { ...consultorio };
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    this.getConsultorios();
    form.resetForm();
    this.consultorio = {} as Consultorio;
  }

}