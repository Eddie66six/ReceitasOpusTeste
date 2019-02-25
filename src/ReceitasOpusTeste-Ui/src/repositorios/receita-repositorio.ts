import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppConfigService } from 'src/app/app-config';

@Injectable({
  providedIn: 'root'
})

export class ReceitaRepositorio {

  constructor(
    private config: AppConfigService,
    private http: HttpClient) { }

  criarReceita(receita: {}) {
    return this.http.post(`${this.config.urlBase}receitas`,receita);
  }

  obterTodasAsReceitas() {
    return this.http.get<any[]>(`${this.config.urlBase}receitas`);
  }

  obterPorId(id: number) {
    return this.http.get(`${this.config.urlBase}receitas/${id}`);
  }

  obterIngredientesDaReceita(id: number) {
    return this.http.get(`${this.config.urlBase}receitas/${id}/ingredientes`);
  }

  obtemReceitasPorIdIngrediente(idIngrediente: number) {
    return this.http.get(`${this.config.urlBase}receitas/-/ingredientes/${idIngrediente}`);
  }

  obtemTodosOsIngredientesUtilizados() {
    return this.http.get(`${this.config.urlBase}receitas/ingredientes`);
  }
}
