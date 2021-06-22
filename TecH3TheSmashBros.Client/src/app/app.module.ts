import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { OrderComponent } from './order/order.component';
import { HomepageComponent } from './homepage/homepage.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ProductEditComponent } from './product-page/product-edit/product-edit.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    OrderComponent,
    ProductPageComponent,
    ProductEditComponent,
    LoginComponent,
    CheckoutComponent,
    ProductEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
