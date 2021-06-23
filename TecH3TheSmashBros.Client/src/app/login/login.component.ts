import { Component, OnInit } from '@angular/core';
import { User, Customer } from '../model';
import { LoginService } from '../service/login.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  users: User[] = [];

  constructor(
    private loginService: LoginService
  ) { }
  editClicked = false;
  createClicked = false;


  createClick() { this.createClicked = true; }

  ngOnInit(): void {
    this.getUsers();
  }


  getUsers(): void {
    this.loginService.getUsers()
      .subscribe(user => {
        this.users = user;
        console.log(this.users);
      });

  }
  addUser(email: string, password: string, firstname: string, lastname: string, street: string, zipcode: string, city: string): void {

    let user: User = {
      email: email,
      password: password,
      customer: [{
        firstname: firstname,
        lastname: lastname,
        street: street,
        zipcode: zipcode,
        city: city
      }]
    }

    console.log("user", user);
    this.loginService.addUser(user)
      .subscribe(user => { this.users.push(user) });

  }
  deleteUser(user: User): void {
    if (confirm(`Are you sure you want to delete:  ${user.email}`)) {
      this.users = this.users.filter(a => a !== user);
      this.loginService.deleteUser(user.id).subscribe();
    }
  }
  updateUser(id: number, email: string, password: string, firstname: string, lastname: string, street: string, zipcode: string, city: string): void {
    let user: User = {
      email: email,
      password: password,
      customer: [{
        firstname: firstname,
        lastname: lastname,
        street: street,
        zipcode: zipcode,
        city: city
      }]
    }
    this.loginService.updateUser(id,user)
      .subscribe(a => {this.users.push(user)})
  }
  getUser(id: number) {
    this.loginService.getUser(id)
      .subscribe(user => { this.users.push(user) });
  }
}
