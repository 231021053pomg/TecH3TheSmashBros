import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { CartItem, Category, Product } from '../model';
import { BasketService } from '../service/basket.service';
import { ProductService } from '../service/product.service';
import { stringify } from '@angular/compiler/src/util';

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

  isAdmin: boolean = true;


  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private productService: ProductService,
    private basketService : BasketService
  ) {}

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
  }

  getProducts(): void {
    //checks if it should sort by categoryId
    if( this.location.path().includes ("products/category/") ){
      var categoryId = (this.route.snapshot.paramMap.get('category_id') || 0) as number;
      this.productService.getProductsByCategoryId(categoryId)
        .subscribe(product => this.products = product)
    } else { //else it just gets everything
      this.productService.getProducts()
        .subscribe(product => this.products = product)
    }
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
    this.openEditProduct(this.products.length - 1);
  }

  openEditProduct(index: number) { //Hides the big + button, and sets the current editing target
    this.productEditIndex = index;
    this.addProductEnabled = false;
  }

  closeEditProduct(){ //Unhides the big + button, and resets the editing target
    this.productEditIndex = -1;
    this.addProductEnabled = true;
  }

  editProduct(product: Product, index: number): void {
    var last_index = this.products.length - 1;

    //adds new product
    if (this.products[index].id == 0) { 
      this.productService.addProduct(product)
        .subscribe(product => {
          this.products[last_index] = product;
          this.closeEditProduct();
        }
      )
    }
    //edits existing product
    else {
      this.productService.updateProduct(this.products[this.productEditIndex].id, product)
        .subscribe(product =>{ //after Api call, the product is updated on the frontend without reloading
          var updated_product = this.products[this.productEditIndex];

          updated_product.title = product.title;
          updated_product.categoryId = product.categoryId;
          updated_product.price = product.price;
          updated_product.storage = product.storage;
          updated_product.images = product.images;

          this.closeEditProduct();
        }
      )
    }
  }

  addCategory(title: string) {
    this.productService.addCategory(title)
      .subscribe(a => this.categories.push(a));

    var input = document.getElementById("category-input") as HTMLInputElement;
    input.value = "";
    this.getCategories();
  }

  editCategory(category: Category,new_title: string){
    this.categoryEditIndex = -1;
    category.title = new_title;
    this.productService.updateCategory(category.id,category).subscribe(
      category => {
        this.getProducts();
        this.getCategories();
      }
    )
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
      this.productService.deleteCategory(id).subscribe(() => this.getCategories());
      //this.categories = this.categories.filter(a => a != category);
    }
  }

  openEditCategory(category: Category) {
    this.categoryEditIndex = category.id;
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
