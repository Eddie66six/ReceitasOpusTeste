import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';

@Injectable()
export class AppConfigService {
  public producao: boolean = environment.production;
  public urlBase: string = environment.apiUrl;

  constructor() {
  }
}
