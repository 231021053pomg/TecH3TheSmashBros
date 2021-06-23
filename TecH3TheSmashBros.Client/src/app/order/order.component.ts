import { Component, OnInit } from '@angular/core';
import { Order } from '../model';
import { OrderService } from '../service/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  orders : Order[] = [];

  constructor(
    private orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.getOrders();
  }
  getTotal(order:Order) {
    let total = 0;
    if (order.orderDetails.length > 0){
      order.orderDetails.forEach((item) => {
        total += Number(item.amount * item.price);
      });
    }
    return total;
  }
  getOrders(): void{
    this.orderService.getOrders().subscribe(a => {
      this.orders = a;
      console.log(this.orders)
    })
  };

}
