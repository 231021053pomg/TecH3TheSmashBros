import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Category, Product } from '../model';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  apiUrl: string = "https://localhost:5001/api/";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type' : 'application/json'})
  }

  constructor(
    private http:HttpClient
  ){ }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl+"products").pipe(
      catchError(this.handleError<Product[]>("getProducts"))
    )
  }

  deleteProduct(id: number): Observable<Product>{
    return this.http.delete<Product>(`${this.apiUrl}products/${id}`).pipe(
      catchError(this.handleError<Product>("deleteProduct"))
    )
  }

  updateProduct(id: number, product: Product): Observable<Product>{
    console.log("update")
    return this.http.put<Product>(`${this.apiUrl}products/${id}`,product,this.httpOptions).pipe(
      catchError(this.handleError<Product>("updateProduct"))
    )
  }

  addProduct(product: Product): Observable<Product>{
    console.log("create")
    return this.http.post<Product>(`${this.apiUrl}products`,product,this.httpOptions).pipe(
      catchError(this.handleError<Product>("addProduct"))
    )
  }

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(`${this.apiUrl}categories`).pipe(
      catchError(this.handleError<Category[]>("getCategories"))
    )
  }

  addCategory(categoryTitle: string): Observable<Category>{
    return this.http.post<Category>(`${this.apiUrl}categories?categoryTitle=${categoryTitle}`, this.httpOptions).pipe(
      catchError(this.handleError<Product>("addCategory"))
    )
  }

  deleteCategory(categoryId: number): Observable<Category>{
    return this.http.delete<Category>(`${this.apiUrl}categories/${categoryId}`).pipe(
      catchError(this.handleError<Product>("deleteCategory"))
    )
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
