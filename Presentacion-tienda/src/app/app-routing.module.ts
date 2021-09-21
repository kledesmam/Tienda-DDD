import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ListadoOrdenClienteComponent } from './pages/listado-orden-cliente/listado-orden-cliente.component';
import { NuevaOrdenComponent } from './pages/nueva-orden/nueva-orden.component';
import { ResumenOrdenComponent } from './pages/resumen-orden/resumen-orden.component';

const routes: Routes = [
  { path: '', redirectTo:'dashboard', pathMatch:'full'},
  { path: 'dashboard', component: DashboardComponent },
  { path: 'listado-orden-cliente', component: ListadoOrdenClienteComponent },
  { path: 'nueva', component: NuevaOrdenComponent },
  { path: 'resumen/:id', component: ResumenOrdenComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [
  DashboardComponent,
  ListadoOrdenClienteComponent,
  NuevaOrdenComponent,
  ResumenOrdenComponent
]