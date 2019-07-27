import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/classes/store';

@Component({
  selector: 'app-store-page',
  templateUrl: './store-page.component.html',
  styleUrls: ['./store-page.component.css']
})
export class StorePageComponent implements OnInit {

thisStore:Store;
  storeName:string = "Coffee";
  constructor() { 
    this.thisStore = new Store(1,
       "Coffee" ,
        "Jerusalem" ,
         "02-2222222" ,
          "the best coffee store!" ,
      "Rabanut Meadrin Jerusalem" ,
      "../assets/Images/IMG_0025.JPG",
      "Coffee & Bakery" ,
       false ,
        false,
      false ,
       false ,
     12 ,
    123 ,
     "12345");
  }

  ngOnInit() {
  }

}
