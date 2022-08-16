import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';  
import {Observable} from 'rxjs'; 
@Injectable({
  providedIn: 'root'
})
export class SharedService {  
  readonly APIUrl = "https://localhost:44321/KalyanJewellers";  
  constructor(private http: HttpClient) {}   

  // UserObj= {};
  count:number=3;


  getUserList(): Observable < any[] > {  
      return this.http.get < any > (this.APIUrl + '/Users');   
  }  
  addUser(val: any) {  
    // val.studentId=this.count;
    // this.UserArray.push(val);
    console.log("------------------------------")
    console.log(val);
      return this.http.post(this.APIUrl + '/SignUp', val);  
  }  
  updateUser(val: any) {  
      return this.http.put(this.APIUrl + '/', val);  
  }  
  deleteUser(val: any) {  
      return this.http.delete(this.APIUrl + '/' + val);  
  }  
  
} 
