import { Component, OnInit } from '@angular/core';
import { CartItem } from '../model';
import { Product } from '../module';
import { BasketService } from '../service/basket.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  products: Product[] = [];
  CartItems: CartItem[] = [];

  constructor(
    private basketService: BasketService
  ) { }

  ngOnInit(): void {
    this.CartItems = JSON.parse(localStorage.getItem('cart'));
    console.log("Checkout", this.CartItems);
  }
  editbasket(id: number, antal: number): void {
    this.basketService.editbasket(id, antal);
    this.CartItems = JSON.parse(localStorage.getItem('cart'));
  }
  deleteBasket(id: number): void {
    console.log("DeleteBasket",id);
    this.basketService.removefrombasket(id);
    this.CartItems = JSON.parse(localStorage.getItem('cart'));
  }
}
