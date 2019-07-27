import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '../classes/store';
import { HttpClient } from '@angular/common/http';
import { StoresMenu } from '../classes/stores-menu';
import { MenuAdditions } from '../classes/menu-additions';
import { MenuTastes } from '../classes/menu-tastes';
import { PurchasesProduct } from '../classes/purchases-product';
import { PurchasesDetailsAddition } from '../classes/purchases-details-addition';
import { PurchaseDetailsTaste } from '../classes/purchase-details-taste';
import { ProductCategory } from '../classes/product-category';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

    public additionsCahnged: EventEmitter<any>= new EventEmitter<any>();

    constructor(private httpClient:HttpClient) { }

    //all this parameters are filled when the user chooses a store.
    menu:Array<StoresMenu> = new Array<StoresMenu>();
    additions:Array<MenuAdditions> = new Array<MenuAdditions>();
    tastes:Array<MenuTastes> = new Array<MenuTastes>();

    URL="http://localhost:4588/";

    setMenu(value)
    {
      this.menu=value;
    }

    getMenu()
    {
      return this.menu;
    }

    setAdditions(value)
    {
      this.additions=value;
    }
    getAdditions()
    {
      return this.additions;
    }

    setTastes(value)
    {
      this.tastes=value;
    }
    getTastes()
    {
      return this.tastes;
    }
    


    getStoreQuickProducts(id):Observable<StoresMenu[]>
    {
      return this.httpClient.get<StoresMenu[]>(this.URL+"api/Menu/GetStoreQuickProducts/"+id);
    }
    
    getStoreAdditions(id):Observable<MenuAdditions[]>
    {
      return this.httpClient.get<MenuAdditions[]>(this.URL+"api/Menu/GetAdditionsByStore/"+id);
    }
    
    getStoreTastes(id):Observable<MenuTastes[]>
    {
      return this.httpClient.get<MenuTastes[]>(this.URL+"api/Menu/GetTastesByStore/"+id);
    }

    //in the store page we neeed to initial this parameter
    storeId:number=1;

    getStoreDetails():Observable<Store>
    {
      debugger;
      return this.httpClient.get<Store>(this.URL+"api/Store/GetStoreDetails/"+this.storeId);
    }

    getStoreMenuCategories():Observable<ProductCategory[]>
    {
      debugger;
      return this.httpClient.get<ProductCategory[]>(this.URL+"api/Menu/GetCategoriesByStore/"+this.storeId);
    }

    getStoreMenu():Observable<StoresMenu[]>
    {
      return this.httpClient.get<StoresMenu[]>(this.URL+"api/Menu/GetByStore/"+this.storeId);
    }
    

    //cart of PurchaseProduct.
    cart:Array<PurchasesProduct>;
    //carts details additions of PurchaseDetailsAddition.
    cartDetailsAdditions:Array<PurchasesDetailsAddition> = new Array<PurchasesDetailsAddition>();
    //carts details tastes of PurchaseDetailsTaste.
    cartDetailsTastes:Array<PurchaseDetailsTaste> = new Array<PurchaseDetailsTaste>();

    //getCart
    //return Array<PurchasesProduct>.
    getCart()
    {
      return this.cart;
    }

    getCartDetailsAdditions()
    {
      return this.cartDetailsAdditions;
    }

    getCartDetailsTastes()
    {
      return this.cartDetailsTastes;
    }

  //addToCart
  //add PurchaseProduct to the cart.
  //parameters:
  //purchaseProduct:PurchasesProduct
  //additions:Array<PurchasesDetailsAddition>
  //taste:PurchaseDetailsTaste
  addToCart(purchaseProduct:PurchasesProduct , additions:Array<PurchasesDetailsAddition> , taste:PurchaseDetailsTaste )
  {
    this.cart.push(purchaseProduct);
    additions.forEach(a=> this.cartDetailsAdditions.push(a));
    this.cartDetailsTastes.push(taste);
  }

  //removeFromCart
  //remove PurchaseProduct from the cart.
  //parameters:
  //purchaseProduct:PurchasesProduct
  removeFromCart( purchaseProduct:PurchasesProduct ){
    //remove the purchaseProduct from the cart.
    this.cart.splice(this.cart.indexOf(purchaseProduct));
    //remove the purchaseDetailsAdditions from the cartDetailsAdditions by purchaseProduct.product(:numebr).
    this.cartDetailsAdditions.forEach(a=> {
      if( a.product == purchaseProduct.product ){
      this.cartDetailsAdditions.splice(this.cartDetailsAdditions.indexOf(a));
    }});
    //remove the pirchaseDetailsTaste from the cartDetailsTastes by purchseProduct.product(:numebr).
    this.cartDetailsTastes.splice(this.cartDetailsTastes.findIndex(t=> t.product == purchaseProduct.product));
  }

  //setCartDetailsAdditions
  //set the PurchaseDetailsAdditions of specific PurchaseProduct.
  //parameters:
  //purchaseProduct:PurchasesProduct 
  //purchaseDetailsAdditions:Array<PurchasesDetailsAddition
  setCartDetailsAdditions( purchaseProduct:PurchasesProduct, purchaseDetailsAdditions:Array<PurchasesDetailsAddition> )
  {
    //remove the old additions.
    this.cartDetailsAdditions.forEach( a=> { if( a.product == purchaseProduct.product )
    {
      this.cartDetailsAdditions.splice(this.cartDetailsAdditions.indexOf(a));
    }});
    //add the new additions.
    purchaseDetailsAdditions.forEach( a=> this.cartDetailsAdditions.push(a) );
  }

  //setCartDetailsTastes
  //set the PurchaseDetailsTaste of specific PurchaseProduct.
  //parameters:
  //purchaseProduct:PurchasesProduct
  //purchaseDetailsTaste:PurchaseDetailsTaste
  setCartDetailsTastes( purchaseProduct:PurchasesProduct , purchaseDetailsTaste:PurchaseDetailsTaste )
  {
    //remove the old taste.
    this.cartDetailsTastes.splice(this.cartDetailsTastes.findIndex(t=> t.product == purchaseProduct.product ));
    //add the new taste.
    this.cartDetailsTastes.push(purchaseDetailsTaste);
  }
}