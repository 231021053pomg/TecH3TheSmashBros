import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './product-page/product-detail/product-detail.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', component: HomepageComponent},
  { path: 'home', component:HomepageComponent},
  { path: 'products/:id',component:ProductDetailComponent},
  { path: 'products',component:ProductPageComponent},
  { path: 'CheckOut', component:CheckoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
