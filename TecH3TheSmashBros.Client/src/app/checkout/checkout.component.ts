import { Component, OnInit } from '@angular/core';
import { CartItem } from '../model';
import { BasketService } from '../service/basket.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  CartItems: CartItem[] = [];

  constructor(
    private basketService: BasketService
  ) { }

  ngOnInit(): void {
    this.CartItems = JSON.parse(localStorage.getItem('cart'));
    console.log("Checkout", this.CartItems);
  }
  openEditBasket(antal: number): void {
    
  }

}
