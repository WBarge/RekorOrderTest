import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  @Input('ProductData')   data!: Product;

  constructor() {
    if (this.data === null)
    {
      this.data = new Product();
    }
   }

  ngOnInit(): void {
  }

}
