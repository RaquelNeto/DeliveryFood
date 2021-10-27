import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatRadioModule} from '@angular/material/radio';

import { SituationRoutingModule } from './situation-routing.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    SituationRoutingModule,
    MatRadioModule
  ]
})
export class SituationModule {
  
 }
