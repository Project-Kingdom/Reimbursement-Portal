import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { LoginComponent } from './Components/login/login.component';
import { ReimbursementsDetailsComponent } from './Components/reimbursements-details/reimbursements-details.component';
import { SignUpComponent } from './Components/sign-up/sign-up.component';

const routes: Routes = [
  // { path: '', component:LoginComponent},
  // { path: 'sign-up', component:SignUpComponent },
  // { path: 'reimbursement', component:ReimbursementsDetailsComponent},
  // { path: 'admin-dashboard', component:AdminDashboardComponent},
];
//ReimbursementsDetails
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
