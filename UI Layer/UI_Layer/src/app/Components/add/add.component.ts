import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
// import { ApiService } from 'src/app/service/api.service';
import { ToastrService } from 'ngx-toastr';
// import { Reimbursement } from 'src/app/model/ReimbursementModel';
import { FormGroup, NgForm } from '@angular/forms';
import { UserService } from 'src/app/service/user.service';
import { Reimbursement } from 'src/app/model/ReimbursementModel';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  userId!: number;
  reNo:string="No";
  date:any
  response: {dbPath: 'y'};
  constructor(public service:UserService,private route: ActivatedRoute,private authService: AuthenticationService,public dialogRef: MatDialogRef<AddComponent>,public toast:ToastrService)
  {}
  
  ngOnInit(): void {
    this.date = new Date().toISOString().slice(0, 10);
    const id = localStorage.getItem('CurrentUserId');
    if(id!=null)
    this.userId = parseInt(id);
    console.log(this.userId);
  }
   imageUrl: string = "../../assets/img/default-image.png";
   selectedImage:any;
  
  onImageSelected(event:any) {
    this.selectedImage = event.target.files[0];
    let reader = new FileReader();
    console.log("rere"+this.selectedImage);
    reader.onload = (e: any) => {
      this.imageUrl = e.target.result;
    };
    reader.readAsDataURL(this.selectedImage);
    this.service.reimbursementData.Receipt="Yes";
    console.log("Select:"+this.imageUrl);
  }
  
  onSubmit(myform:NgForm){
    // if(this.imageUrl!=null)this.reNo="Yes"
    // this.service.reimbursementData.Receipt=this.reNo;
    if(this.service.reimbursementData.ReimbursementId==0)
      this.insertReimbursement(myform);
     else
     this.updateReimbursement(myform);
  }

  insertReimbursement(myform:NgForm)
  {  
    this.service.reimbursementData.UserId=this.userId;
    console.log(this.service.reimbursementData.UserId);
    if(this.response!=null)
    this.service.reimbursementData.Receipt=this.response.dbPath;
    else this.service.reimbursementData.Receipt="No";
    this.service.CreateReimbursement().subscribe((data:any)=> {
      console.log(data);
      this.resetForm(myform);
      this.refereshData();
      this.toast.success('Success','Claim Added');
     },
     (err:any)=>{
      this.resetForm(myform);
      this.refereshData();
      this.toast.success('Success','Claim Added');
      
    });
    this.onClose()
  }

  updateReimbursement(myform:NgForm)
  {
    this.service.EditReimbursement(this.service.reimbursementData).subscribe((d:any)=> {
      this.resetForm(myform);
      this.refereshData();
      this.toast.success('Success','Claim Updated');
    },
    err=>{
      this.toast.success('Success','Claim Updated');
    }
    );
    this.onClose()
  }

  uploadFinished = (event:any) => { 
    this.response = event; 
  }

  resetForm(myform:NgForm)
  {
    myform.form.reset(myform.value);
    this.service.reimbursementData=new Reimbursement();
  }

  refereshData()
  {
    console.log(this.userId);
    this.service.getReimbursementsforUser(this.userId).subscribe((res:any)=>{
      this.service.reimbursementList=res;
    });
  }

  onClose(){
    this.service.reimbursementData=new Reimbursement();
    this.dialogRef.close();
  }
}
