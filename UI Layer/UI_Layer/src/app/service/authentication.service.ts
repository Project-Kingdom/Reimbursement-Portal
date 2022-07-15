import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private router: Router) { }

  getCurrentUser() {
    return localStorage.getItem('CurrentUserId');
  }
  isLoggedIn() {
    let authToken = localStorage.getItem('CurrentUserId');
    return (authToken != null) ? true : false;
  }
  logout() { 
    let removeCurrentUser = localStorage.removeItem('CurrentUserId');
    let Approver = localStorage.getItem('Approver');
    if(Approver != null)
    {
      localStorage.removeItem('Approver');
    }
      this.router.navigate(['login']);
  }
  isLoggedInAdmin() {
    let Approver = localStorage.getItem('Approver');
    return (Approver != null) ? true : false;
  }
}
