import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CartItem, Category, Product } from '../model';
import { BasketService } from '../service/basket.service';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent implements OnInit {
  products: Product[] = [];
  categories: Category[] = [];
  addProductEnabled: boolean = true;
  productEditIndex: number = -1;

  
  constructor(
    private productService : ProductService,
    private formBuilder: FormBuilder,
    private basketService : BasketService
  ) {}


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
    this.addProductEnabled = false;

    var product: Product = {
      id: 0,
      title: "",
      storage: 0,
      categoryId: 0,
      price: 0,
      images: ""
    };
    this.products.push(product);
    this.productEditIndex = this.products.length-1;
  }

  openEditProduct(index: number){
    this.productEditIndex = index;
    this.addProductEnabled = false;
  }

  editProduct(product: Product, index: number): void{
    var last_index = this.products.length-1;

    if(this.products[index].id == 0){ //adds new product
      this.productService.addProduct(product)
        .subscribe( a => this.products[last_index] = a )
    }
    else { //edits existing product
      this.productService.updateProduct(this.products[this.productEditIndex].id, product)
        .subscribe( a => this.products[this.productEditIndex] = a)
    }
    this.productEditIndex = -1;
    this.addProductEnabled = true;
  }
  // buyProduct(product): void{
  //   var cart = []
  //   cart.push({ product.id, })
  // }
  AddBasket(product : Product):void{
    console.log(product.id,product.title,product.price,1);
    this.basketService.PutInBasket(product.id,product.title,product.price,1);
  }
}
