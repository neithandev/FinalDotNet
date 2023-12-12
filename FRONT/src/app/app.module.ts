import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { AlunoCadastrarComponent } from "./pages/aluno/aluno-cadastrar/aluno-cadastrar.component";
import { ImcCadastrarComponent } from "./pages/imc/imc-cadastrar/imc-cadastrar.component";
import { FormsModule } from '@angular/forms';



@NgModule({
    declarations: [
        AppComponent,
        AlunoCadastrarComponent,
        ImcCadastrarComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
