import { Component, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ApiRoutes } from '../../app/shared/ApiRoutes/ApiRoutes';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {

  usersList = [];
  freeUsersList = [];
  premiumUsersList = [];
  folkPremiumUsersList = [];

  constructor(private http: Http) {
    this.GetUsersList();
  }

  GetUsersList() {

    try {
      const _this = this;

      this.http.get(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.GetUsersList).subscribe(result => {
        debugger;
        var resultJson = result.json();

        if (result.status == 200) {
          this.usersList = resultJson.resultData;

          if (this.usersList.length > 0) {
            debugger;
            this.usersList.forEach(function (value) {

              switch (value.accountTypeId) {
                case 1:
                  _this.freeUsersList.push(value);
                  break;

                case 2:
                  _this.premiumUsersList.push(value);
                  break;

                case 3:
                  _this.folkPremiumUsersList.push(value);
                  break;
              }
            });
          }
          else {
            console.log("Sonething went wrong.")
          }
        }
        else {
          console.log(result)
        }
      });
    }
    catch (e) {
      console.log(e);
    }
  }
}
