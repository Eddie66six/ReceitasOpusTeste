import { Component, OnInit } from '@angular/core';
import { ReceitaRepositorio } from 'src/repositorios/receita-repositorio';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ComumService } from 'src/servicos/ComumService';

@Component({
  selector: 'app-listar-receitas',
  templateUrl: './listar-receitas.component.html',
  styleUrls: ['./listar-receitas.component.css']
})
export class ListarReceitasComponent implements OnInit {
  public receitas: any= [];
  public ingredientes: any= [];
  public paginaAtual: number = 1;
  public qtdPorPagina: number = 5;
  public total: number = 0;

  public paginaAtualDetalhes: number = 1;
  public qtdPorPaginaDetalhes: number = 5;
  public totalDetalhes: number = 0;
  public receitaDetalhes: any = {};

  constructor(
    private receitaRepositorio: ReceitaRepositorio,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: NgbModal,
    private comumService: ComumService
  ) { }

  ngOnInit() {
    this.obterReceitas();
  }
  async obterReceitas() {
    this.spinner.show();
    this.receitaRepositorio.obterTodasAsReceitas().subscribe(async data => {
      this.receitas = data;
      this.total = this.receitas.length;
      this.spinner.hide();
    }, async error => {
      this.spinner.hide();
      this.toastr.error(this.comumService.obterMensagemErro(error), 'Erro', { timeOut: 3000 });
    });
  }

  async abrirModalDetalhes(content,receita){
    this.obterIngredientesReceita(content,receita);
  }

  async obterIngredientesReceita(content,receita) {
    this.spinner.show();
    this.receitaRepositorio.obterIngredientesDaReceita(receita.idReceita).subscribe(async data => {
      this.ingredientes = data;
      this.totalDetalhes = this.ingredientes.length;
      this.receitaDetalhes = receita;
      this.spinner.hide();
      this.modalService.open(content, { size: 'lg' });
    }, async error => {
      this.spinner.hide();
      this.toastr.error(this.comumService.obterMensagemErro(error), 'Erro', { timeOut: 3000 });
    });
  }
}
