import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { Http, Headers, RequestOptions } from '@angular/http';
import { ApiRoutes } from '../../app/shared/ApiRoutes/ApiRoutes';
import { UserVM, ResponseVm, httpStatus } from '../../app/shared/Common/Classes';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  public appValForm: FormGroup;
  public userVm: UserVM = new UserVM();
  public response: ResponseVm = new ResponseVm();

  //common: Common = new Common()

  constructor(private router: Router, private http: Http, private buider: FormBuilder) {
  }
  ngOnInit(): void {
    this.appValForm = this.buider.group({
      email: [''],
      password: ['']
    });

  }

  ProceedToLogin() {
    debugger;
    this.appValForm.value;
    debugger;
    this.userVm.email = this.appValForm.value.email;
    this.userVm.password = this.appValForm.value.password;
    this.userVm.isAdmin = true;

    try {
      this.http.post(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.LoginAdmin, this.userVm).subscribe(result => {
        this.response = result.json();
        if (this.response.status == httpStatus.Ok) {
          this.router.navigate(['/dashboard']);
        }
      });
    }
    catch (e) {

    }
  }
}
