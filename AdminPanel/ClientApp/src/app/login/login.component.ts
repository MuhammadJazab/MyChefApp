import { Component, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ApiRoutes } from '../../app/shared/ApiRoutes/ApiRoutes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  TxtEmail: string;
  TxtPassword: string;

  constructor(private http: Http) {
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
    // this.http.post();
  }
}
