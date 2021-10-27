import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatCardModule} from '@angular/material/card';

import { CategoryRoutingModule } from './category-routing.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    CategoryRoutingModule,
    MatProgressSpinnerModule,
    MatCardModule
  ]
})
export class CategoryModule { }
