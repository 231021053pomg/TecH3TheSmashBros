import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductDetailComponent } from './product-page/product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { HomepageComponent } from './homepage/homepage.component';
import { ProductPageComponent } from './product-page/product-page.component';

const routes: Routes = [
  { path: 'home', component:HomepageComponent},
  { path: 'CheckOut', component:CheckoutComponent},
  { path: 'product', component:ProductPageComponent}
  /* { path: '', redirectTo: '/CheckOut', component: CheckoutComponent}, */
  { path: 'products/:id',component:ProductDetailComponent},
  { path: 'products',component:ProductPageComponent},
  { path: 'CheckOut', component:CheckoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
