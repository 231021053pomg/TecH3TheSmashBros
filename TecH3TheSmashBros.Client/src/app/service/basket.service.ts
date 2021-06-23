import { HttpClient, HttpHeaders } from '@angular/common/http';
import { asNativeElements, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ObserveOnSubscriber } from 'rxjs/internal/operators/observeOn';
import { Category, Product } from '../model';
import { catchError, tap } from 'rxjs/operators';
import { CartItem } from '../model';
import { isNgTemplate } from '@angular/compiler';
import { ɵInternalFormsSharedModule } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class BasketService {
  apiUrl: string = "https://localhost:5001/api/";
  Cart: CartItem[] = [];
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor(
    private http: HttpClient
  ) { }
  ngOnInit(): void {

  }

  createbasket(): void {
    let cart = localStorage.getItem('cart')
    if (cart == null || cart == 'null')  {
      this.Cart = [];
      console.log("LOCALSTORAGE NULL", JSON.parse(localStorage.getItem('cart')));
      localStorage.setItem('cart', JSON.stringify(this.Cart));
      console.log('Pushed first Item: ', this.Cart);
    }
    else {

      this.Cart = JSON.parse(localStorage.getItem('cart'));
      console.log("LOCAL STORAGE HAS ITEMS", JSON.parse(localStorage.getItem('cart')));
      localStorage.setItem('cart', JSON.stringify(this.Cart));
    }
  }
  PutInBasket(id: number, navn: string, pris: number, antal: number): any {
    this.createbasket();
    var newItem = true;
    this.Cart.forEach(function (item) {
      if (item.productid == id) {
        item.antal += antal;
        newItem = false;
      }
    });
    if (newItem == true) {
      let Cartitem: CartItem = ({
        productid: id,
        navn,
        pris,
        antal
      }) as CartItem;
      this.Cart.push(Cartitem)
    };
    this.SaveBasket()
  }
  SaveBasket(): void {
    localStorage.setItem('cart', JSON.stringify(this.Cart));
  }
  getBasket(): Observable<CartItem[]> {
    return of(this.Cart);
  }
  editbasket(id: number, antal: number): void {
    this.createbasket();
    this.Cart.forEach(function (item) {
      if (item.productid == id) {
        item.antal = antal;
      }
    });

    this.SaveBasket()
  }
  removefrombasket(id: number): void {
    this.createbasket();
    console.log("BasketService før slet",this.Cart);
    for(let i = this.Cart.length - 1; i >= 0; i--) {
      if (this.Cart[i].productid == id) {
        console.log("BasketService Imens den sletter",i)
        this.Cart.splice(i, 1)
      }
    };
    console.log("Efter den har slettede",this.Cart);
    
    this.SaveBasket();
  }
  buyeverthing(): Observable<CartItem[]> {
    let order = {
      "userId": 1,
      "date": "2021-06-22T11:44:22.869Z",
      orderDetails: []
    } 
    this.createbasket();
    this.Cart.forEach(function(item){
      order.orderDetails.push({
        "productsId": item.productid,
        "price": item.pris,
        "amount": item.antal
      })
    });
    console.log("buyeverything");
    return this.http.post<CartItem[]>(`${this.apiUrl}Order`, order, this.httpOptions).pipe(
      tap(_ => {localStorage.setItem('cart',null)}),
      catchError(this.handleError<CartItem[]>("addOrder"))
    );
        
  }
  // editBasket() : CartItem[]{

  // }

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


