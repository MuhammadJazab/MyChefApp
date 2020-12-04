import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuVM, ResponseVm, httpStatus } from '../shared/Common/Classes';
import { Http, Response } from '@angular/http';
import { ApiRoutes } from '../shared/ApiRoutes/ApiRoutes';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})

export class DemoComponent implements OnInit {
  public appValForm: FormGroup;
  public menuvm: MenuVM = new MenuVM();
  public respons: ResponseVm = new ResponseVm();
  public submitted = false;
  public menueList = [];
  public messageShow: boolean = false;
  public menuId;
  public recipies;
  public ShowHideForm: boolean = true;
  public listCount: number;

  constructor(private formBuilder: FormBuilder, private http: Http) { }

  public ngOnInit(): void {
    this.appValForm = this.formBuilder.group({
      day: ['', [Validators.required]],
      title: ['', [Validators.required]],
      direction: ['', Validators.required],
      gridient: ['', [Validators.required]]
    });

    this.GetMenuCount();
    this.GetMenuItem();
  }

  GetMenuItem() {
    this.http.get(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.GetMenuItem).subscribe(result => {
      this.menueList = result.json().resultData;
    });
  }

  GetMenuCount() {
    this.http.get(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.GetMenuCount).subscribe(result => {
      this.listCount = result.json().resultData;
      if (this.listCount <= 5) {
        this.ShowHideForm = true;
      }
      else {
        this.ShowHideForm = false;
      }
    });
  }

  get f() { return this.appValForm.controls; }

  submitt() {
    this.submitted = true;
    if (this.appValForm.valid) {
      this.menuvm.day = this.appValForm.value.day;
      this.menuvm.title = this.appValForm.value.title;
      this.menuvm.direction = this.appValForm.value.direction;
      for (var i = 0; i < this.appValForm.value.gridient.length; i++) {
        this.menuvm.inGridient.push(this.appValForm.value.gridient[i].value);
      }
      this.http.post(ApiRoutes.BaseUrl.baseUrl + ApiRoutes.Admin.AddMenuItem, this.menuvm).subscribe(result => {
        debugger;
        this.respons = result.json();
        if (this.respons.status == httpStatus.Ok) {
          this.GetMenuItem();
          this.messageShow = true;
        }
      });
    }
    else {
      return;
    }
  }

  updateMenu(item) {
    debugger;
    this.menuvm.menuId = item.menuId;
    this.menuvm.menuRecipeId = item.menuRecipeId;
    this.appValForm.patchValue(item);
    this.appValForm.controls.gridient.setValue(item.inGridient);
  }
}
