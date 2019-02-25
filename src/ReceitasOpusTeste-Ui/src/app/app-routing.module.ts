import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CriarReceitaComponent } from './criar-receita/criar-receita.component';
import { ListarReceitasComponent } from './listar-receitas/listar-receitas.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'nova', component: CriarReceitaComponent },
  { path: 'receitas', component: ListarReceitasComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
