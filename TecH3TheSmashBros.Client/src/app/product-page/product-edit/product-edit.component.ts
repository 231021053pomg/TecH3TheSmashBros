import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Category } from 'src/app/model';
import { ProductService } from 'src/app/service/product.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  categories: Category[] = [];

  @Output() updateEvent = new EventEmitter<boolean>();

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

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories(): void {
    this.productService.getCategories()
      .subscribe(category => this.categories = category)
  }

  editProduct(): void {
    console.warn('Your order has been submitted', this.productForm.value);
    this.productForm.reset();
  }

  submit(): void {
    var product = this.productForm.value;
    this.updateEvent.emit(product);
  }
}
