import { Injectable, Inject, EventEmitter, Output } from '@angular/core';

@Injectable({
    providedIn: 'root'
})

export class ComumService {

    constructor() { }

    obterMensagemErro(error) {
        console.log(error);
        return error != null && error.error != null && error.error.length > 0 ? error.error.map(function(e) {
            return e.mensagem;
          }).join(', ') : 'Ocorreu um erro inesperado, tente novamente';
    }
}
