import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Category, Product } from '../model';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {

  products: Product[] = [];
  categories: Category[] = [];
  addProductEnabled: boolean = false;

  productForm = this.formBuilder.group({
    title: "",
    price: 0,
    storage: 0,
    categoryId: 1,
    images: "",
  });

  constructor(
    private productService : ProductService,
    private formBuilder: FormBuilder

  ) { }

  ngOnInit( ): void {
    this.getProducts();
    this.getCategories();
  }


  getProducts(): void {
      this.productService.getProducts()
        .subscribe(product => this.products = product)
  }

  getCategories(): void {
    this.productService.getCategories()
      .subscribe(category => this.categories = category)
  }

  deleteProduct(product: Product){
    this.products = this.products.filter(a => a != product);
    this.productService.deleteProduct(product.id).subscribe()
  }

  addProduct(): void {
    console.warn('Your order has been submitted', this.productForm.value);
    this.productForm.reset();
  }

  addProductToggle(): void{
    if (this.addProductEnabled) this.addProductEnabled = false;
    else this.addProductEnabled = true;
  }
  // buyProduct(product): void{
  //   var cart = []
  //   cart.push({ product.id, })
  // }
}
