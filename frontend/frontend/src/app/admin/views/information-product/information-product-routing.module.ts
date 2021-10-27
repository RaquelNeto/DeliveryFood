import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InformationProductComponent } from "./information-product.component";

const routes: Routes = [
  {path: "", component: InformationProductComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InformationProductRoutingModule { }
