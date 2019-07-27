import { Component, OnInit } from '@angular/core';
import { StoresMenu } from 'src/app/classes/stores-menu';
import { Router, ActivatedRoute } from '@angular/router';
import { StoreService } from 'src/app/services/store.service';


@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {
products:Array<StoresMenu>;
  constructor(private httpServ:StoreService, private router:Router, private activatedRoute:ActivatedRoute) { 
    let category;
    //get the parameters 
    activatedRoute.params.subscribe(params=>{category=params["category"]});
    //get the products from the service by the category.
    this.products = httpServ.getMenu().filter(m=>m.productCategory==category);


    //this.products = [new StoresMenu(1,1,"Omlet" , 1 , 35 , true , true , 1 ,      "../assets/Images/omlet.jpg" ),
    //new StoresMenu(2,1,"Waffel" , 2 , 40 , true , true , 1 ,   "../assets/Images/waffel-mit-eis-schoko.jpg" )];

  }

  ngOnInit() {
  }


  productChosen(id:number)
  {
    //navigate to the product page
    this.router.navigate(['/product', id]);
  }
}
