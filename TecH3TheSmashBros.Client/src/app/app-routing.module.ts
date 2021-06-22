import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  // { path: '', redirectTo: '/CheckOut', component: CheckoutComponent},
  { path: 'CheckOut', component:CheckoutComponent},
  { path: 'Login', component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
