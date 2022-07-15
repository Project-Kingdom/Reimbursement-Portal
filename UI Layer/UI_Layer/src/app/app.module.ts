import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { ReimbursementsDetailsComponent } from './Components/reimbursements-details/reimbursements-details.component'

import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddComponent } from './Components/add/add.component';
import { ToastrModule } from 'ngx-toastr';
import { DatePipe } from '@angular/common';
import { DeleteDialogComponent } from './Components/delete-dialog/delete-dialog.component';
import { SignUpComponent } from './Components/sign-up/sign-up.component';
import { LoginComponent } from './Components/login/login.component';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './Shared/auth.guard';
import { AuthadminGuard } from './Shared/authadmin.guard';
import { ApproveFormComponent } from './Components/approve-form/approve-form.component';
import { DeclineComponent } from './Components/decline/decline.component';
import { UploadImageComponent } from './Components/upload-image/upload-image.component';
import { PageNotFoundComponent } from './Components/page-not-found/page-not-found.component';
// import {MatIconModule} from '@angular/material/icon';
@NgModule({
  declarations: [
    AppComponent,
    ReimbursementsDetailsComponent,
    AddComponent,
    DeleteDialogComponent,
    SignUpComponent,
    LoginComponent,
    AdminDashboardComponent,
    ApproveFormComponent,
    DeclineComponent,
    UploadImageComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule,
    // ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'signup', component: SignUpComponent },
      { path: 'userReimbursement/:id', component: ReimbursementsDetailsComponent ,canActivate : [AuthGuard] },
      { path: 'admin/:id', component: AdminDashboardComponent,canActivate:[AuthadminGuard] },
      // { path: 'decline', component: DeclineComponent ,canActivate:[AuthadminGuard]},
      { path: '**', component: PageNotFoundComponent },
      { path: '', redirectTo: 'login', pathMatch: 'full' },
    ])
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
  // entryComponents:[ReimbursementsDetailsComponent]
})
export class AppModule { }
