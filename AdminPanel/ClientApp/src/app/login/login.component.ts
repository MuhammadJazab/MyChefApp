import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Http, Headers, RequestOptions } from '@angular/http';
import { ApiRoutes } from '../../app/shared/ApiRoutes/ApiRoutes';
import { UserVM } from '../../app/shared/Common/Classes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  TxtEmail: string;
  TxtPassword: string;

  userVm: UserVM = new UserVM();
  //common: Common = new Common()

  constructor(private router: Router, private http: Http) {
  }

  public Login() {
    if (this.TxtEmail != null) {
      if (this.TxtPassword != null) {
        this.ProceedToLogin(this.TxtEmail, this.TxtPassword)
      } else {
        // password is empty
      }
    }
    else {
      // Email is empty
    }
  }

  private ProceedToLogin(_email: string, _password: string) {

    this.userVm.email = _email;
    this.userVm.password = _password;
    this.userVm.isAdmin = true;

    try {
      this.http.post(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.LoginAdmin, this.userVm).subscribe(result => {
        debugger;
        var aa = result.json();
        if (true) {
       //   this.common.NavigateToRoute("DashboardComponent")
        } else {

        }
      })
    }
    catch (e) {

    }
  }
}
