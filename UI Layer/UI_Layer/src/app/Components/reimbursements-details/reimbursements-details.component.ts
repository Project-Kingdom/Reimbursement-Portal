import { Component, OnInit } from '@angular/core';
// import { ApiService } from 'src/app/service/api.service';
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { AddComponent } from '../add/add.component';
import { ToastrService } from 'ngx-toastr';
// import { Reimbursement } from 'src/app/model/ReimbursementModel';
import { DatePipe } from '@angular/common';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { UserService } from 'src/app/service/user.service';
import { Reimbursement } from 'src/app/model/ReimbursementModel';
import { ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { User } from 'src/app/model/UserModel';
@Component({
  selector: 'app-reimbursements-details',
  templateUrl: './reimbursements-details.component.html',
  styleUrls: ['./reimbursements-details.component.css']
})
export class ReimbursementsDetailsComponent implements OnInit {
  userId: number
  constructor(public service:UserService,private route: ActivatedRoute,
    private authService:AuthenticationService ,public datepipe:DatePipe,public dialog: MatDialog,public toast:ToastrService){
  }
  ngOnInit(): void {
    const id = localStorage.getItem('CurrentUserId');
    if(id!=null)
    this.userId = parseInt(id); 
    //this.route.snapshot.params['id'];
    console.log(this.userId);
    this.service.getReimbursementsforUser(this.userId).subscribe((data:any)=>{
      this.service.reimbursementList=data;
      console.log(this.service.reimbursementList)
    })
  }
  logout() {
    this.service.userData=new User();
    this.authService.logout();
  }
  onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "60%";
    this.dialog.open(AddComponent,dialogConfig);
  }

  update(selecetedReimbursement:Reimbursement)
  {
    console.log(selecetedReimbursement);

     let df=this.datepipe.transform(selecetedReimbursement.Date,'yyyy-MM-dd');
     selecetedReimbursement.Date=df;
     this.service.reimbursementData=selecetedReimbursement;
     const dialogConfig = new MatDialogConfig();
     dialogConfig.disableClose = true;
     dialogConfig.autoFocus = true;
     dialogConfig.width = "60%";
     this.dialog.open(AddComponent,dialogConfig);
  }

  delete(id:number)
  {
    console.log(id);
    this.service.reimbursementData.ReimbursementId=id;
    const dialogConfig = new MatDialogConfig();
     dialogConfig.disableClose = true;
     dialogConfig.autoFocus = true;
     dialogConfig.width = "40%";
    //  dialogConfig.position.top ="10px";
     this.dialog.open(DeleteDialogComponent,{
      width: '390px',
      panelClass: 'confirm-dialog-container',
      disableClose: true,
      position: { top: "10px" },
     });
  }

  public createImgPath = (serverPath: string) => { 
    console.log(serverPath);
    return `https://localhost:44371/${serverPath}`; 
  }

}
