import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { Customers } from './views/customer/customers';
import { Products } from './views/product/products';
import { Orders } from './views/order/orders';

const routes: Routes = [
  { path: 'customer', component: Customers },
  { path: 'product', component: Products },
  { path: 'order', component: Orders },
  {
      path: '',
      redirectTo: '/customer',
      pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
