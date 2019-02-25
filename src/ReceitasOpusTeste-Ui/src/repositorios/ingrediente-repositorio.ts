import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppConfigService } from 'src/app/app-config';

@Injectable({
  providedIn: 'root'
})

export class IngredienteRepositorio {

  constructor(
    private config: AppConfigService,
    private http: HttpClient) { }

  obterIngredientes() {
    return this.http.get<any[]>(`${this.config.urlBase}ingredientes`);
  }
}
