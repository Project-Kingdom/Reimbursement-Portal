import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { UserService } from 'src/app/service/user.service';
import { ApproveFormComponent } from '../approve-form/approve-form.component';
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  pageNo:number=0
  requestedBy : string = '';
  reimbursementType : string = '';
  constructor( private authService:AuthenticationService,public service:UserService,public dialog: MatDialog) { }

  ngOnInit(): void {
    this.service.getAllPendingRequest().subscribe(data=>{
      this.service.adminReimbursementList=data;
      console.log(data);
    })
  }
  logout() {
    this.authService.logout();
  }
  onCreate(id:number)
  {
    this.service.approveReimbursementData.ReimbursementId=id
    const dialogConfig = new MatDialogConfig();
    this.dialog.open(ApproveFormComponent,{
      width: '60%',
      //panelClass: 'confirm-dialog-container',
      disableClose: true,
      autoFocus : true,
      position: { bottom: "60px" },
     });
  }
  pendingTable(){
    this.pageNo=0
    this.service.getAllPendingRequest().subscribe(data=>{
      this.service.adminReimbursementList=data;
      console.log(data);
    })
  }
  declineTable()
  {
    this.pageNo=1;
    this.service.getAllDeclinedRequest().subscribe(data=>{
      this.service.adminReimbursementList=data;
    })
  }

  approvedTable()
  {
    this.pageNo=1;
    this.service.getAllAcceptedRequest().subscribe(data=>{
      this.service.adminReimbursementList=data;
    })
  }
  decline(id:number){
    console.log("id: "+id);
    this.service.declineReimbursementData.ReimbursementId=id;
    this.service.DeclineReimbursement(this.service.declineReimbursementData).subscribe(
      data=>{
        this.service.getAllPendingRequest().subscribe(data=>{
          this.service.adminReimbursementList=data;
          console.log(data);
        })
      }
    );
    window.location.reload();
  }
  SearchRequestedBy(email : string) {
    this.requestedBy = email;
  }
}