import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { max } from 'rxjs/operators';
import { Category, Product } from '../model';
import { BasketService } from '../service/basket.service';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  constructor(
    private productService : ProductService,
    private formBuilder: FormBuilder,
    private basketService : BasketService
  ) { }

  ngOnInit(): void {
    this.getProducts();
  }
  getProducts(): void {
    this.productService.getProducts()
    .subscribe(products => {
      this.products = products.sort(() => Math.random() - Math.random()).slice(0,3);
    });
   }
AddBasket(product : Product):void{
  console.log(product.id,product.title,product.price,1);
  this.basketService.PutInBasket(product.id,product.title,product.price,1);
}

}
