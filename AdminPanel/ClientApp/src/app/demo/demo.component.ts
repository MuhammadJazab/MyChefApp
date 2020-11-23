import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MenuVM } from '../shared/Common/Classes';
import { Http } from '@angular/http';
import { ApiRoutes } from '../shared/ApiRoutes/ApiRoutes';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})
export class DemoComponent implements OnInit {
  public appValForm: FormGroup;
  public menuvm: MenuVM = new MenuVM();
  public submitted = false;


  constructor(private formBuilder: FormBuilder, private http: Http) { }

  public ngOnInit(): void {
    this.appValForm = this.formBuilder.group({
      day: ['', [Validators.required]],
      title: ['', [Validators.required]],
      direction: ['', Validators.required],
      gridient: ['', [Validators.required]]
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
        var aa = result.json();
      });
    }
    else {
      return;
    }
   
  


  }
  

}
