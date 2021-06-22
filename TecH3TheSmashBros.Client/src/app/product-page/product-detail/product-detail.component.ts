import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Product } from 'src/app/model';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  id : number = 0;
  product: Product;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private productService: ProductService
  ) { }

  ngOnInit(): void {
    this.getProduct();
  }

  getProduct(): void {
    this.id = (this.route.snapshot.paramMap.get('id') || 0) as number;
    this.productService.getProduct(this.id).subscribe(
      product => {
        this.product = product;
      });
    if (this.product == null) {
      this.location.go("/products")
    }
  }

}
