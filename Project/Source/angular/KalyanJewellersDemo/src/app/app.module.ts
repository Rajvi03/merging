import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsersComponent } from './users/users.component';
import { SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http'; 
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ShowDeleteUsersComponent } from './users/show-delete-users/show-delete-users.component';
import { AddEditUsersComponent } from './users/add-edit-users/add-edit-users.component';
import { AdminHomeComponent } from './admin-home/admin-home.component'; 
@NgModule({
  declarations: [
    AppComponent,
    UsersComponent,
    ShowDeleteUsersComponent,
    AddEditUsersComponent,
    AdminHomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
