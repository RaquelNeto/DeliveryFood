import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SituationComponent } from "./situation.component";

const routes: Routes = [
  {path: "", component: SituationComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SituationRoutingModule { }
