import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from "./players/list/list.component";
const routes: Routes = [];

RouterModule.forRoot([
  { path: 'players', component: ListComponent }
])

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
