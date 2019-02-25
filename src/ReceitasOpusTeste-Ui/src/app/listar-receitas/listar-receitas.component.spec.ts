import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarReceitasComponent } from './listar-receitas.component';

describe('ListarReceitasComponent', () => {
  let component: ListarReceitasComponent;
  let fixture: ComponentFixture<ListarReceitasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarReceitasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarReceitasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
