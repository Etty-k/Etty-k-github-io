import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { StoreMenuComponent} from './components/store-menu/store-menu.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { OrderComponent } from './components/order/order.component';
import { ProductComponent } from './components/product/product.component';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { QuickOrderComponent } from './components/quick-order/quick-order.component';
import { StorePageComponent } from './components/store-page/store-page.component';

import { RoutingModule } from './routing/routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    StoreMenuComponent,
    NotFoundComponent,
    OrderComponent,
    ProductComponent,
    ProductsListComponent,
    QuickOrderComponent,
    StorePageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule,
    RoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
