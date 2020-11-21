import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-demo',
  templateUrl: './demo.component.html',
})
export class DemoComponent implements OnInit {
  public usersList = [];
  public text = "Hello Word";
  constructor() { }

  public ngOnInit(): void {
    debugger;
    this.GetUsersList();
  }
  GetUsersList() {
    debugger;
    let freeuser = { userId: 1, userName: 'xyz', email: 'muhammadawais@gamil.com', accountTypeId: 'Active', cookingSkillId: 'abc' };
    for (var i = 0; i < 5; i++) {
      this.usersList.push(freeuser);
      console.log(this.usersList);
    }
  }

}
