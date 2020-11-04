import { Component, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { ApiRoutes } from '../../app/shared/ApiRoutes/ApiRoutes';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  constructor(
    private http: Http,
    /*private headers = new Headers({ 'Content-Type': 'application/json' })*/) {

  }

  ngOnInit() {
    this.GetUsersList();
  }
  GetUsersList() {
    debugger;
    this.http.get(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.GetFinishedJobs).subscribe(
      result => {
        debugger;
        var aa = result.json();
      });
  }

}
