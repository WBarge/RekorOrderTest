import { Component, Input, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Customer } from 'src/app/models/customer';
import { Order } from 'src/app/models/order';
import { Product } from 'src/app/models/product';
import { CustomerServiceService } from 'src/app/services/customer-service.service';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  productList: Product[];
  customerList: Customer[];

  @Input('OrderData')   data!: Order;
  constructor(private messageService:MessageService,private productService:ProductServiceService,private customerService:CustomerServiceService) { 
    this.productList = new Array<Product>();
    this.customerList = new Array<Customer>();
  }

  ngOnInit(): void {
    this.loadProducts();
    this.loadCustomers();
  }

  loadProducts() {
    this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
    this.productService.getProducts().subscribe(
      {
        next: (dataset: Product[])=> {
          this.productList = dataset;
          this.messageService.clear;
        },
        error: e=>this.handleError(e)
    });
  }

  loadCustomers() {
    this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Customers' });
    this.customerService.getCustomers().subscribe(
      {
        next: (dataset: Customer[])=> {
          this.customerList = dataset;
          this.messageService.clear;
        },
        error: e=>this.handleError(e)
    });
  }

  handleError(errorMsg: string): void {
    this.messageService.clear();
    this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
  }

}

