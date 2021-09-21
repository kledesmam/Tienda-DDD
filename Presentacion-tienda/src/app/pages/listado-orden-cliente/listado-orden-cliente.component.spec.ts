import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoOrdenClienteComponent } from './listado-orden-cliente.component';

describe('ListadoOrdenClienteComponent', () => {
  let component: ListadoOrdenClienteComponent;
  let fixture: ComponentFixture<ListadoOrdenClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListadoOrdenClienteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListadoOrdenClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
