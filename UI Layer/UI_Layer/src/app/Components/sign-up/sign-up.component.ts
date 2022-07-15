import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/model/UserModel';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  // SampleUser: User = {
  //   UserEmail:'',
  //   UserPassword:'',
  //   UserName:'',
  //   UserBank:'',
  //   UserPanNumber:'',
  //   UserBAN:'',
  //   Approver:'No'
  // };
  EmailAvailable : boolean = true;
  // User: User = { ...this.SampleUser };
  constructor(public service: UserService, private router: Router) { }

  ngOnInit(): void {
  //   console.log(localStorage.getItem('Approver'));
  //  console.log(localStorage.getItem('CurrentUserId'));
  }
  onSubmit(signupform: NgForm) {
    console.log(this.service.userData);
    this.service.EmailAvailable(this.service.userData.UserEmail).subscribe((result : any) => {
      console.log(result.available)
      if(result.available)
      {
        console.log("User"+this.service.userData);
        this.service.CreateUser().subscribe(
          data=>{
            console.log(data);
            this.resetForm(signupform);
          }
          // result => console.log('Sucess' + result),
          // error => console.log('Error' + error)
        );
        this.resetForm(signupform);
        this.service.userData=new User()
        this.router.navigate(['login']);
      }
      else
      {
        this.EmailAvailable = false;
      }
    }
    );
  }

  resetForm(signupform:NgForm)
  {
    signupform.form.reset(signupform.value);
    this.service.userData=new User();
  }

  refereshData()
  {
    // this.service.getReimbursement().subscribe(res=>{
    //   this.reimService.reimbursementList=res;
    // });
  }
}
