import { Component, OnInit } from '@angular/core';
import { StoreService } from 'src/app/services/store.service';
import { ProductCategory } from 'src/app/classes/product-category';
import { Router } from '@angular/router';

@Component({
  selector: 'app-store-menu',
  templateUrl: './store-menu.component.html',
  styleUrls: ['./store-menu.component.css']
})
export class StoreMenuComponent implements OnInit {

  //temp variable until we'll create the router
  storeId:number=1;
  categories:Array<ProductCategory>;
  
  constructor(private httpServ:StoreService, private router:Router) { 
    httpServ.getStoreMenuCategories().subscribe(
      data=>{this.categories=data},
      err=>{alert(err)}
    );
  }

  getAdditions(name)
  {
    this.httpServ.getAdditions().find(a=>a.product==name);
  }

  ngOnInit() {
    
  }

  categoryChosen(c:ProductCategory)
  {
    this.router.navigate(["/productsList/",c.Id ]);
  }

}
