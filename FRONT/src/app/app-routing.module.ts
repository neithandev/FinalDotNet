import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AlunoCadastrarComponent } from "./pages/aluno/aluno-cadastrar/aluno-cadastrar.component";
import { ImcCadastrarComponent } from "./pages/imc/imc-cadastrar/imc-cadastrar.component";

const routes: Routes = [
    {
        path: "",
        component: AlunoCadastrarComponent,
    },
    {
        path: "pages/aluno/aluno-cadastrar",
        component: AlunoCadastrarComponent,
    },
    {
        path: "pages/imc/imc-cadastrar",
        component: ImcCadastrarComponent,
    }

];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule { }
