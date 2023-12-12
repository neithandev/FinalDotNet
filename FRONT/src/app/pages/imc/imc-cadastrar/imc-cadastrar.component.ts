import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Imc } from '../../../models/imc.models';
import { Aluno } from '../../../models/aluno.models';

@Component({
  selector: 'app-imc-cadastrar',
  templateUrl: './imc-cadastrar.component.html',
  styleUrls: ['./imc-cadastrar.component.css']
})
export class ImcCadastrarComponent implements OnInit {
  alunoSelecionado: number = 0;
  altura: number = 0;
  peso: number = 0;
  alunos: Aluno[] = [];

  constructor(private client: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.client
      .get<Aluno[]>("https://localhost:7052/aluno/listar")
      .subscribe({
        next: (data) => {
          console.table(this.alunos);
          this.alunos = data;
        },
        error: (erro) => {
          console.log(erro);
        }
      });
  }

  cadastrarImc(): void {
    let imc: Imc = {
      alunoId: this.alunoSelecionado,
      Metros: this.altura,
      Peso: this.peso
    };
  
    this.client.post<Imc>("https://localhost:7052/imc/cadastrar", imc).subscribe({
      next: () => {
        console.log(imc)
        this.alunoSelecionado = 0;
        this.altura = 0;
        this.peso = 0;
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
  
}