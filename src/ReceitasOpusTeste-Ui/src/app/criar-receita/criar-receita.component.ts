import { Component, OnInit } from '@angular/core';
import { IngredienteRepositorio } from 'src/repositorios/ingrediente-repositorio';
import { ReceitaRepositorio } from 'src/repositorios/receita-repositorio';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ComumService } from 'src/servicos/ComumService';

@Component({
  selector: 'app-criar-receita',
  templateUrl: './criar-receita.component.html',
  styleUrls: ['./criar-receita.component.css']
})
export class CriarReceitaComponent implements OnInit {
  public dropdownList = [];
  public selectedItems = [];
  public dropdownSettings = {};

  public receita: any = {};
  registerForm: FormGroup;
  submitted = false;
  constructor(
    private ingredienteRepositorio: IngredienteRepositorio,
    private receitaRepositorio: ReceitaRepositorio,
    private formBuilder: FormBuilder,
    private router: Router,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private comumService: ComumService
  ) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      porcoes: ['', Validators.required],
      calorias: ['', [Validators.required]],
      modoDePreparo: ['', [Validators.required, Validators.minLength(50), Validators.maxLength(1000)]],
      ingredientes: ['', [Validators.required]]
    });

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'idIngrediente',
      textField: 'nome',
      selectAllText: 'Selecionar todos',
      unSelectAllText: 'Remover todos',
      allowSearchFilter: true
    };
    this.obterIngredientes();
  }

  get f() { return this.registerForm.controls; }

  async obterIngredientes() {
    this.spinner.show();
    this.ingredienteRepositorio.obterIngredientes().subscribe(async data => {
      this.dropdownList = data;
      this.spinner.hide();
    }, async error => {
      this.spinner.hide();
      this.toastr.error(this.comumService.obterMensagemErro(error), 'Erro', { timeOut: 3000 });
    });
  }

  async salvarReceita() {
    this.spinner.show();
    this.receita.idsIngredientes = this.selectedItems.map(function (val) {
      return val.idIngrediente;
    });
    this.submitted = true;
    if (this.registerForm.invalid || this.receita.idsIngredientes.length == 0) {
      this.spinner.hide();
      return;
    }
    this.receitaRepositorio.criarReceita(this.receita).subscribe(async data => {
      setTimeout(() => {
        this.spinner.hide();
        this.toastr.success('Salvo com sucesso', 'Sucesso');
        this.router.navigateByUrl('');
    }, 1000);
    }, async error => {
      this.spinner.hide();
      this.toastr.error(this.comumService.obterMensagemErro(error), 'Erro');
    });
  }

}
