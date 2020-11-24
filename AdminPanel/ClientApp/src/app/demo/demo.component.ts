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


  constructor(private formBuilder: FormBuilder, private http: Http) { }

  public ngOnInit(): void {
    this.appValForm = this.formBuilder.group({
      day: ['', [Validators.required]],
      title: ['', [Validators.required]],
      direction: ['', Validators.required],
      gridient: ['', [Validators.required]]
    });

    this.GetMenuItem();

  }
  GetMenuItem() {
    debugger;
    this.http.get('http://localhost:8800/api/Admin/GetMenuItem').subscribe(result => {
      debugger;
      this.menueList = result.json();
    });
    }

  get f() { return this.appValForm.controls; }

  submitt() {
    debugger;
    this.submitted = true;
    if (this.appValForm.valid) {
      this.menuvm.day = this.appValForm.value.day;
      this.menuvm.title = this.appValForm.value.title;
      this.menuvm.direction = this.appValForm.value.direction;
      for (var i = 0; i < this.appValForm.value.gridient.length; i++) {
        this.menuvm.inGridient.push(this.appValForm.value.gridient[i].value);
      }
      debugger;
      this.http.post('http://localhost:8800/api/Admin/AddMenuItem', this.menuvm).subscribe(result => {
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
  

}
