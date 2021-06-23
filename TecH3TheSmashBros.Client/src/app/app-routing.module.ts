import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './product-page/product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { HomepageComponent } from './homepage/homepage.component';
import { OrderComponent } from './order/order.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component:HomepageComponent},
  { path: 'products',component:ProductPageComponent},
  { path: 'Orders', component:OrderComponent},
  { path: 'products/category',component:ProductPageComponent},
  { path: 'products/category/:category_id',component:ProductPageComponent},
  { path: 'products/:id',component:ProductDetailComponent},
  { path: 'CheckOut', component:CheckoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
