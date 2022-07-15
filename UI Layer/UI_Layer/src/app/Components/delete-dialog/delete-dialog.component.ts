import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
// import { ApiService } from 'src/app/service/api.service';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent implements OnInit {
  CurrentUser!: string | null;
  userId: number;
  constructor(public service: UserService,
    private route: ActivatedRoute, public authService: AuthenticationService, public toast: ToastrService, public dialogRef: MatDialogRef<DeleteDialogComponent>) { }
  ngOnInit(): void {

    // const id = this.route.snapshot.params['id'];
    // console.log(id);
    // this.CurrentUser = this.authService.getCurrentUser();
    // if (this.CurrentUser != null) {
    //   this.service.reimbursementData.UserId = parseInt(this.CurrentUser);
    //   console.log(this.service.reimbursementData.UserId)
    // }
    const id = localStorage.getItem('CurrentUserId');
    if (id != null)
      this.userId = parseInt(id);
    console.log("Id: " + this.userId)
  }
  // userId = this.route.snapshot.params['id'];

  delete(correct: boolean, id: number) {
    if (correct) {
      console.log(id)
      this.service.reimbursementData.ReimbursementId = id;
      this.service.DeleteReimbursement().subscribe((error: any) => {
        // this.toast.success('Success','Claim Deleted');
        (error: any) => this.toast.success('Success','Claim Deleted');
        // console.log(data);
        // console.log("reimid is: "+this.service.reimbursementData.UserId);
        // this.service.getReimbursementsforUser(this.userId).subscribe((result)=>{
        //   this.service.reimbursementList=result;
        //   this.toast.success('Success','Claim Deleted');
        // });
      },
      );
      this.closeDialog();
      window.location.reload();
      setTimeout(() => {
        this.toast.success('Success','Claim Deleted');
        // console.log("Waited For: " + 1000 + " seconds");
        window.location.reload();
        // Call the setDelay function again with the remaining times
    }, 2000);
      this.toast.success('Success','Claim Deleted');
    }
    else {
      this.toast.error('Unsuccess','Claim not Deleted');
      console.log("reimid: " + id);
      this.closeDialog()
    }
  }

  closeDialog() {
    this.dialogRef.close(false);
  }

}
