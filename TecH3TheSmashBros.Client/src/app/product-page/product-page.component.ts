import { Component, OnInit } from '@angular/core';
import { Product } from '../model';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  products: Product[] = [];
  constructor(
    private productService : ProductService
  ) { }

  ngOnInit( ): void {
    this.getProducts();
  }


  getProducts(): void {
      this.productService.getProducts()
        .subscribe(product => this.products = product)
  }
}
