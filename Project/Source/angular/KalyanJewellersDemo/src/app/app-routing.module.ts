import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { AddEditUsersComponent } from './users/add-edit-users/add-edit-users.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
  
  
const routes: Routes = [  
{path:'Users/allUsers',component:UsersComponent},
{path:'SignUp/addUsers',component:AddEditUsersComponent},
{path:'Products',component:ProductsComponent},
{path:'Admin',component:AdminHomeComponent},
  
];  
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
