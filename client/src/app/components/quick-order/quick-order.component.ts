import { Component, OnInit } from '@angular/core';
import { StoresMenu } from 'src/app/classes/stores-menu';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quick-order',
  templateUrl: './quick-order.component.html',
  styleUrls: ['./quick-order.component.css']
})
export class QuickOrderComponent implements OnInit {

  productsList:Array<StoresMenu>;
  constructor(private router:Router) {
    //select the quick order products from the service.
    //this.productsList = [new StoresMenu(1,1,"Ice coffee" , "coffee" , 5 , true , true , 1 ,      "../assets/Images/iceCoffee.JPG" ),
    //new StoresMenu(1,1,"Sandwitch" , "Bakery" , 15 , true , true , 1 ,   "../assets/Images/IMG_0025.JPG" )];

   }

order(id:number){
this.router.navigate(["/order", id]);
}

  ngOnInit() {
  }


  
}
