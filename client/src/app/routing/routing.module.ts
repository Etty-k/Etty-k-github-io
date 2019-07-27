import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { ProductsListComponent } from '../components/products-list/products-list.component';
import { StorePageComponent } from '../components/store-page/store-page.component';
import { ProductComponent } from '../components/product/product.component';
import { QuickOrderComponent } from '../components/quick-order/quick-order.component';
import { NotFoundComponent } from '../components/not-found/not-found.component';
import { OrderComponent } from '../components/order/order.component';


const routes:Routes = [
  {path:"" , component: StorePageComponent },
  {path:"products - list/:category" , component:  ProductsListComponent },
  {path:"product/:product" , component: ProductComponent },
  {path:"quick - order" , component: QuickOrderComponent },
  {path:"store - page" , component:StorePageComponent },
  {path:"order/:id" , component:OrderComponent },
  {path:"not-found" , component:NotFoundComponent },
  {path:"**" , redirectTo:"/not-found" }
]

@NgModule({
  imports: [
    CommonModule , RouterModule.forRoot(routes)
  ],
  declarations: []
})




export class RoutingModule {
 }