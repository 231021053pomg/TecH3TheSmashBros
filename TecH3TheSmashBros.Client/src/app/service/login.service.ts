import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { User, Customer } from '../model';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  apiUrl: string = "https://localhost:5001/api/";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(
    private http: HttpClient

  ) { }
  ngOnInit(): void {
    this.getUsers();

  }

  getUser(id: number): Observable<User>{
    return this.http.get<User>(`${this.apiUrl}user/${id}`).pipe(
      catchError(this.handleError<User>("getUser"))
    )
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl + "user").pipe(
      catchError(this.handleError<User[]>("getUsers"))
    )
  }

  deleteUser(id: number): Observable<User> {
    return this.http.delete<User>(`${this.apiUrl}user/${id}`).pipe(
      catchError(this.handleError<User>("deleteUser"))
    )
  }

  updateUser(id: number, user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}user/${id}`, user, this.httpOptions).pipe(
      catchError(this.handleError<User>("updateUser"))
    )
  }

  addUser(user: User): Observable<User> {
    console.log(user);
    return this.http.post<User>(`${this.apiUrl}user/`, user, this.httpOptions).pipe(
      catchError(this.handleError<User>("addUser"))
    );

  }
  



  /**
    * Handle Http operation that failed.
    * Let the app continue.
    * @param operation - name of the operation that failed
    * @param result - optional value to return as the observable result
    */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
