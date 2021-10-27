import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {  InformationDeliverComponent } from './information-deliver.component';

const routes: Routes = [
  {path: "", component: InformationDeliverComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InformationDeliverRoutingModule { }
