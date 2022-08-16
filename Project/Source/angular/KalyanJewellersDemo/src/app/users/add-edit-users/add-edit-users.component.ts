import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-users',
  templateUrl: './add-edit-users.component.html',
  styleUrls: ['./add-edit-users.component.css']
})
export class AddEditUsersComponent implements OnInit {

  constructor(private service: SharedService) { }

  usersDetails!: FormGroup;
  ngOnInit(): void {
    this.usersDetails = new FormGroup({
      UsersId: new FormControl(this.service.count),
      FirstName: new FormControl(),
      LastName: new FormControl(),
      Email: new FormControl(),
      MobileNo: new FormControl(),
      Password: new FormControl(),

    })
    this.usersDetails.get('studentId')?.disable();
  }

  addUser: any = [];
  userObj: any = {};

  addUserFromService() {
    this.addUser.push(this.usersDetails.value);
    // this.addUser.forEach(function (value:any) {
    //   obj[value.id] = value.name
    // }); 
    var arrayToString = JSON.stringify(Object.assign({}, this.addUser));  // convert array to string
    var stringToJsonObject = JSON.parse(arrayToString);  // convert string to json object
    console.log(stringToJsonObject);

    this.service.addUser(this.usersDetails.value).subscribe(data => {
      alert(data.toString)
      console.log(data);
    });
  }
}
