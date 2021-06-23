import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category, Product } from 'src/app/model';
import { ProductService } from 'src/app/service/product.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {
  
  categories: Category[] = [];
  
  @Input() product : Product
  @Output() updateEvent = new EventEmitter<boolean>();
  @Output() cancelEvent = new EventEmitter<boolean>();

  constructor(
    private productService : ProductService,
    public formBuilder: FormBuilder,

  ) { }

  productForm = this.formBuilder.group({
    title: "",
    price: 0,
    storage: 0,
    categoryId: 1,
    images: "",
  });

  productInitial: Product;

  ngOnInit(): void {
    this.getCategories();
    this.productForm.controls['title'].setValue(this.product.title);
    this.productForm.controls['price'].setValue(this.product.price);
    this.productForm.controls['storage'].setValue(this.product.storage);
    this.productForm.controls['categoryId'].setValue(this.product.categoryId);
    this.productForm.controls['images'].setValue(this.product.images);
  }

  getCategories(): void {
    this.productService.getCategories()
      .subscribe(category => {
        this.categories = category;
      }
    )
  }

  editProduct(): void {
    console.warn('Your order has been submitted', this.productForm.value);
    this.productForm.reset();
  }

  submit(): void {
    var product = this.productForm.value;
    product.categoryId = parseInt(product.categoryId);
    console.log(product)
    this.updateEvent.emit(product);
  }

  cancel(): void {
    this.cancelEvent.emit();
  }
}
