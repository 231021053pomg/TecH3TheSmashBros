import { Component, OnInit } from '@angular/core';
import { User, Customer } from '../model';

import { LoginService } from '../service/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Users: User[] = [];
  

  constructor(
    private loginService : LoginService
  ) { }
  isClicked=false;
  createClicked=false;

  onClick(){this.isClicked=true;}
  createClick(){this.createClicked=true;}

  ngOnInit(): void {
  }

  getUser():void{
    this.loginService.getUser()
    .subscribe(user => this.Users = user);
    
  }
  addUser(email:any, password:any):void{
    this.loginService.addUser({email, password} as User)
    .subscribe(user => {this.Users.push(user)});
    
  }
  deleteUser(user:User):void{
    if(confirm(`Are you sure you want to delete:  ${user.email}`)){
      this.Users = this.Users.filter(a => a !== user);
      this.loginService.deleteUser(user.id).subscribe();
    }
    
  }

}
