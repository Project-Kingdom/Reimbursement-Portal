import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/model/UserModel';
import { Reimbursement } from 'src/app/model/ReimbursementModel';
import { AdminReimbursement } from 'src/app/model/AdminReimbursementModel';
import { ApproveReimbursement } from '../model/ApproveModel';
import { DeclineReimbursement } from '../model/DeclineModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  private readonly baseURL = 'https://localhost:44371/api';

  userList:User[]=[]; //For Getting Data UserList
  userData:User=new User(); 
  reimbursementList:Reimbursement[]=[]; //For Getting Data ReimbursementList
  reimbursementData:Reimbursement=new Reimbursement();
  adminReimbursementList:AdminReimbursement[]=[]; //For Getting Data AdminReimbursementList
  adminReimbursementData:AdminReimbursement=new AdminReimbursement(); 
  approveReimbursementList:ApproveReimbursement[]=[]; //For Getting Data AdminReimbursementList
  approveReimbursementData:ApproveReimbursement=new ApproveReimbursement(); 
  declineReimbursementData:DeclineReimbursement=new DeclineReimbursement()

  CreateUser() {
    console.log(this.userData);
    if(this.userData.UserEmail=="admin@gmail.com") this.userData.Approver="Yes";
    else this.userData.Approver="No";
    return this.http.post(this.baseURL+'/User', this.userData);
  }
  EmailAvailable(email:string)
  {
    return this.http.get(this.baseURL+'/Auth/emailAvailable/'+email);
  }

  Login(){
    if(this.userData.UserEmail=="admin@gmail.com")this.userData.Approver="Yes";
    else this.userData.Approver="No";
    this.userData.UserBAN="No";
    this.userData.UserBank="No";
    this.userData.UserName="No";
    return this.http.post<any>(this.baseURL+'/Auth/Login',this.userData);
  }

  CreateReimbursement():any{
    // if(this.reimbursementData.Receipt==null)this.reimbursementData.Receipt="No";
    return this.http.post<any>(this.baseURL+'/Reimbursement/CreateReimbursement',this.reimbursementData);
  }
  getReimbursementsforUser(userId:Number):Observable<Reimbursement[]>{
    return this.http.get<Reimbursement[]>(this.baseURL+'/Reimbursement/getReimbursementsforUser/'+userId);
  }

  public GetReimbursement() : Observable<Reimbursement[]> {
    return this.http.get<Reimbursement[]>(this.baseURL+'/Reimbursement/GetReimbursement');
  }

  public EditReimbursement(reimbursement : Reimbursement) : Observable<any> {
    return this.http.put(this.baseURL+'/Reimbursement/EditReimbursement', reimbursement);
  }
  
  getAllPendingRequest():Observable<AdminReimbursement[]>{
    return this.http.get<AdminReimbursement[]>(this.baseURL+'/Reimbursement/getAllPendingRequest');
  }

  getAllAcceptedRequest():Observable<AdminReimbursement[]>{
    return this.http.get<AdminReimbursement[]>(this.baseURL+'/Reimbursement/getAllAcceptedRequest');
  }

  getAllDeclinedRequest():Observable<AdminReimbursement[]>{
    return this.http.get<AdminReimbursement[]>(this.baseURL+'/Reimbursement/getAllDeclinedRequest');
  }

  public DeleteReimbursement() {
    return this.http.delete(this.baseURL+'/Reimbursement/deleteReimbursement/'+this.reimbursementData.ReimbursementId);
  }

  DeclineReimbursement(DeclineReimbursement:DeclineReimbursement):Observable<any>{
    return this.http.put(this.baseURL+'/Reimbursement/DeclineReimbursement',DeclineReimbursement);
  }

  ApproveReimbursement():Observable<any>{
    return this.http.post<any>(this.baseURL+'/Reimbursement/ApporveReimbursement',this.approveReimbursementData);
  }

}
