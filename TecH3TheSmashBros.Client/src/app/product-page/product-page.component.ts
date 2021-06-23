import { Component, OnInit } from '@angular/core';
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
  categoryEditIndex: number = -1;


  constructor(
    private productService: ProductService,
    private basketService : BasketService
  ) {}

  ngOnInit(): void {
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

  deleteProduct(product: Product) {
    this.products = this.products.filter(a => a != product);
    this.productService.deleteProduct(product.id).subscribe()
  }

  addProduct(): void {
    this.addProductEnabled = false;

    var product: Product = {
      id: 0,
      title: "",
      storage: 0,
      categoryId: 0,
      category: {
        id: 0,
        title: "",
      },
      price: 0,
      images: ""
    };
    this.products.push(product);
    this.productEditIndex = this.products.length - 1;
  }

  openEditProduct(index: number) {
    this.productEditIndex = index;
    this.addProductEnabled = false;
  }

  editProduct(product: Product, index: number): void {
    var last_index = this.products.length - 1;

    if (this.products[index].id == 0) { //adds new product
      this.productService.addProduct(product)
        .subscribe(a => this.products[last_index] = a)
    }
    else { //edits existing product
      this.productService.updateProduct(this.products[this.productEditIndex].id, product)
        .subscribe(a => this.products[this.productEditIndex] = a)
    }
    this.productEditIndex = -1;
    this.addProductEnabled = true;
  }

  addCategory(title: string) {
    this.productService.addCategory(title)
      .subscribe(a => this.categories.push(a));

    var input = document.getElementById("category-input") as HTMLInputElement;
    input.value = "";
  }

  deleteCategory(category: Category) {
    var id = category.id;
    var found = false;
    for (var i = 0; i < this.products.length; i++) {
      if (this.products[i].categoryId == id) {
        found = true;
        break;
      }
    }

    if (found){
      alert(`can't delete ${category.title} while it's referenced by products`)
    } else {
      this.productService.deleteCategory(id);
      this.categories = this.categories.filter(a => a != category);
    }
  }

  openEditCategory(category: Category) {
    this.categoryEditIndex = category.id;
  }

  editCategory(category: Category){
    this.categoryEditIndex = -1;
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
