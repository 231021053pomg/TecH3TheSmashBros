import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ObserveOnSubscriber } from 'rxjs/internal/operators/observeOn';
import { Category, Product } from '../model';
import { catchError, tap } from 'rxjs/operators';
import { CartItem } from '../model';


@Injectable({
  providedIn: 'root'
})
export class BasketService {
  apiUrl: string = "https://localhost:5001/api/";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(
    private http: HttpClient
  ) { }
  // getbasket():CartItem[]{
  //   let local_storage;
  //   let itemsInCart = []
  //   if(localStorage.getItem('cart')  == null){
  //     local_storage =[];
  //     console.log("LOCALSTORAGE NULL",JSON.parse(localStorage.getItem('cart')));
  //     localStorage.setItem('cart', JSON.stringify(itemsInCart));
  //     console.log('Pushed first Item: ', itemsInCart);
  //   }
  //   else
  //   {
  //     local_storage = JSON.parse(localStorage.getItem('cart'));
  //     console.log("LOCAL STORAGE HAS ITEMS",JSON.parse(localStorage.getItem('cart')));
  //     for(var i in local_storage)
  //     {
  //       console.log(local_storage[i].product.id);
        
  //   }
  //   local_storage.forEach(function (item){
  //     itemsInCart.push(item);
  //   })
  //   localStorage.setItem('cart', JSON.stringify(itemsInCart));

  //   }

  // }
  putinbasket(id: number, navn:string, pris:number, antal:number): any {
    var cart = []
    // .pipe(
    //   catchError(this.handleError<Product>("putbasket"))
    // )
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


