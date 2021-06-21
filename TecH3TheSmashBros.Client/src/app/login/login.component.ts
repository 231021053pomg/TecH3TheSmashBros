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

  onClick(){this.isClicked=true;}
  ngOnInit(): void {
    
  }

}
