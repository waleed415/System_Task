import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthModule } from './auth/auth.module';

const routes: Routes = [
  {path:'auth', loadChildren:() => import('./auth/auth.module').then(m => m.AuthModule) },
  {path:'', loadChildren:() => import('./auth/auth.module').then(m => m.AuthModule) },
  {path:'employee', loadChildren:() => import('./employee/employee.module').then(m => m.EmployeeModule) }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
