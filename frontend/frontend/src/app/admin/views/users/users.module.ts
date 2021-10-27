import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { CreateUserComponent } from './components/crud/create-user/create-user.component';
import { DeleteUserComponent } from './components/crud/delete-user/delete-user.component';
import { UserCardComponent } from './components/user-card/user-card.component';
import { UserRowComponent } from './components/user-row/user-row.component';
import { UsersGridComponent } from './views/users-grid/users-grid.component';
import { UsersListComponent } from './views/users-list/users-list.component';
//import { CreateUserDialogComponent } from './components/dialogs/create-user/create-user.component';
//import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';


@NgModule({
  declarations: [
    UsersComponent,
    CreateUserComponent,
    DeleteUserComponent,
    UserCardComponent,
    UserRowComponent,
    UsersGridComponent,
    UsersListComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatSelectModule
  ]
})
export class UsersModule { }
