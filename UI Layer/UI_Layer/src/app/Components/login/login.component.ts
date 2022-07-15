import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/model/UserModel';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  InvalidAttempt: boolean
  constructor(public service: UserService, private router: Router) { }

  ngOnInit(): void {
  }
  errorMessage: any;

  onSubmit(myform: NgForm) {
    console.log(this.service.userData);
    this.service.Login().subscribe(
      (data: any) => {
        console.log(data);
        if (data.status) {
          const id = data.UserId;
          if (data.Approver == "Yes") {
            localStorage.setItem('Approver', data.Approver);
            this.router.navigate(['/admin', data.UserId]);
          }
          else {
            localStorage.setItem('CurrentUserId', data.UserId);
            this.router.navigate(['/userReimbursement', data.UserId]);
          }

        }
        else {
          myform.resetForm();
          this.router.navigate(['/login']);
        }
      },
      (error: { message: any; }) => {
        this.InvalidAttempt = true
        myform.resetForm();
        this.service.userData = new User();
        this.errorMessage = error.message;
      }

    );
  }
  register(myform:NgForm)
  {
    // myform.resetForm();
    this.service.userData=new User();
    this.router.navigate(['/signup']);
  }
}
