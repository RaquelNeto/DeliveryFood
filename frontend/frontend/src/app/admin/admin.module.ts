import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatRadioModule} from '@angular/material/radio';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { DashboardComponent } from './views/dashboard/dashboard.component';
import { CategoryFormComponent } from './views/category/category-form/category-form.component';
import { CategoryListComponent } from './views/category/category-list/category-list.component';
import { DeliverComponent } from './views/deliver/deliver.component';
import { InformationDeliverComponent } from './views/information-deliver/information-deliver.component';
import { SituationComponent } from './views/situation/situation.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { AddProductComponent } from './views/add-product/add-product.component';
import { InformationProductComponent } from './views/information-product/information-product.component';


@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    CategoryFormComponent,
    CategoryListComponent,
    DeliverComponent,
    InformationDeliverComponent,
    SituationComponent,
    AddProductComponent,
    InformationProductComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatListModule,
    MatMenuModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatTableModule,
    MatDatepickerModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatAutocompleteModule,
    MatRadioModule,
    MatProgressBarModule
  ]
})
export class AdminModule { }
