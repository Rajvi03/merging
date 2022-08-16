import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { FormControl, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-show-delete-users',
  templateUrl: './show-delete-users.component.html',
  styleUrls: ['./show-delete-users.component.css']
})
export class ShowDeleteUsersComponent implements OnInit {

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshUserList();
  }
  UserList:any = [];
  
  refreshUserList(){
    this.service.getUserList().subscribe(data=>{
      this.UserList = data;
      console.log(data);
    });
  }
  
}
