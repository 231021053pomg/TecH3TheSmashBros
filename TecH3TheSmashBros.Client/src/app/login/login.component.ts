import { Component, OnInit } from '@angular/core';
import { User } from '../model';

import { LoginService } from '../service/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Logins: User[] = [];

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
    .subscribe(Logins => this.Logins = Logins);
    
  }
  addUser(email:any, password:any):void{
    let Logins = {email, password} as User;
    this.loginService.addUser(Logins)
    .subscribe(Login => {this.Logins.push(Login)});
  }
  deleteUser(Logins:User):void{
    if(confirm(`Are you sure you want to delete:  ${Logins.email}`)){
      this.Logins = this.Logins.filter(a => a !== Logins);
      this.loginService.deleteUser(Logins.id).subscribe();
    }
    
  }

}
