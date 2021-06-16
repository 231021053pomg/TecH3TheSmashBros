import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
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
  productEditId: number = -1;

  
  constructor(
    private productService : ProductService
    ) { };



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

  addProduct(): void{
    //product with id -1 acts as a new valueless product
    if(this.products.length == 0 || this.products[this.products.length-1].id != -1){
      var product: Product = {
        id: -1,
        title: "",
        storage: 0,
        categoryId: 0,
        price: 0,
        images: "",
        category: {id: 0, title: ""}
      };
      this.products.push(product);
      this.productEditId = -1;
    } 
  }

  editProduct(product: Product): void{
    if(product.id == -1){
      this.productService.addProduct(product);
      
    } else {
      //update
    }
    this.products = this.products.filter(a => a != product);
    this.productService.deleteProduct(product.id).subscribe()
  }
}
