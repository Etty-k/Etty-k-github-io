import { Component, OnInit } from '@angular/core';
import { StoresMenu } from 'src/app/classes/stores-menu';
import { StoreService } from 'src/app/services/store.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PurchasesProduct } from 'src/app/classes/purchases-product';
import { PurchasesDetailsAddition } from 'src/app/classes/purchases-details-addition';
import { PurchaseDetailsTaste } from 'src/app/classes/purchase-details-taste';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  thisProduct:StoresMenu;
  additions:Array<PurchasesDetailsAddition>= new Array<PurchasesDetailsAddition>();
  taste:PurchaseDetailsTaste;
  constructor(private httpServ:StoreService, private router:Router, private activatedRoute:ActivatedRoute) { 
    //get the product id from the routing parameters
    let prodId;
    activatedRoute.params.subscribe(params=>prodId=params["product"]);
    //select the chosen product by the id 
    this.thisProduct = httpServ.getMenu().find(m=>m.id==prodId);

    //get new addition from the child component- additions by event emitter through the service
    //and put its values in new variable of type 'PurchasesDetailsAddition'.
    let newAddition;
    this.httpServ.additionsCahnged.subscribe(data=>newAddition=
                                              new PurchasesDetailsAddition(
                                                0,
                                                data.product,
                                                data.id
                                              ));
    //check if this addition exists in the array:
    //if it dosn't exist- add it to the array
    //and if it exists- remove it from the array.
    if(this.additions.find(a=>a.addition==newAddition.id)!=null)
    {
      this.additions.splice(this.additions.indexOf(newAddition));
    }
    else
    {
      this.additions.push(newAddition);
    }
   }

  ngOnInit() {
  }

  addToCart(quantity)
  {
    let purchasesProduct= new PurchasesProduct(0, 0, this.thisProduct.id, quantity, this.thisProduct.productPrice)
    this.httpServ.addToCart(purchasesProduct, this.additions, this.taste);
  }

}
