import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderInformationRoutingModule } from './order-information-routing.module';
import { OrderInformationComponent } from './order-information.component';


@NgModule({
  declarations: [
    OrderInformationComponent
  ],
  imports: [
    CommonModule,
    OrderInformationRoutingModule
  ]
})
export class OrderInformationModule { }
