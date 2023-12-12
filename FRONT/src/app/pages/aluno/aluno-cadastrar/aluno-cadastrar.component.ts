import { Component } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Aluno } from '../../../models/aluno.models';

@Component({
  selector: 'app-aluno-cadastrar',
  templateUrl: './aluno-cadastrar.component.html',
  styleUrl: './aluno-cadastrar.component.css'
})
export class AlunoCadastrarComponent {
  nome: string = "";
  DataNascimento: string = "";

  constructor(private client: HttpClient, private router: Router) { }

  cadastrar(): void {
    let aluno: Aluno = {
      alunoId: 0,
      nome: this.nome,
      DataNascimento: this.DataNascimento
    };

    this.client.post<Aluno>("https://localhost:7052/aluno/cadastrar", aluno).subscribe({
      next: (aluno) => {
        this.nome = "";
        this.DataNascimento = "";
        console.log(aluno);
        this.router.navigate(["pages/imc/imc-cadastrar"]);
      },
      error: (erro) => {
        console.log(erro);
      },
    });
  }
}

