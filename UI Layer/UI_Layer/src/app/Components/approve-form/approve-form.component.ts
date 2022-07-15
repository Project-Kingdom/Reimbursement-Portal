import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApproveReimbursement } from 'src/app/model/ApproveModel';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-approve-form',
  templateUrl: './approve-form.component.html',
  styleUrls: ['./approve-form.component.css']
})
export class ApproveFormComponent implements OnInit {
  adminId:number
  constructor(public service:UserService,private route: ActivatedRoute,private authService: AuthenticationService,public dialogRef: MatDialogRef<ApproveFormComponent>,public toast:ToastrService) { }

  ngOnInit(): void {
    // const id = localStorage.getItem('CurrentUserId');
    // if(id!=null)
    // this.adminId = parseInt(id);
    // console.log(this.adminId);
  }
  onSubmit(form:NgForm){
    // this.service.approveReimbursementData.ReimbursementId=25;
    // this.service.approveReimbursementData.UserId=3;
    console.log(this.service.approveReimbursementData);
    this.service.ApproveReimbursement().subscribe()
    {
      console.log("HI");
      (error: any) => {console.log(error)};
    }
    this.resetForm(form);
    this.refereshData();
    this.onClose();
    window.location.reload();
  }

  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.service.approveReimbursementData=new ApproveReimbursement();
  }

  refereshData()
  {
    // console.log(this.userId);
    this.service.getAllPendingRequest().subscribe(data=>{
      this.service.adminReimbursementList=data;
      console.log(data);
    })
  }

  onClose(){
    this.dialogRef.close();
  }
}
