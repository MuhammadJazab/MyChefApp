import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})
export class DemoComponent implements OnInit {
  public appValForm: FormGroup;

  constructor(private formBuilder:FormBuilder) { }

  public ngOnInit(): void {
    this.appValForm = this.formBuilder.group({
      day: [],
      title: [],
      direction: [],
      gridient:[]
    });
  }

  submitt() {
    debugger;
    var aa = this.appValForm.value;
    var bb = this.appValForm.value.gridient[0].value;
    debugger;
  }
  

}
