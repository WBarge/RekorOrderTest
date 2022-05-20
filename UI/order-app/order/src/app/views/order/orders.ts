import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { ErrorHandler } from 'src/app/helpers/error-handler';
import { Order } from 'src/app/models/order';
import { PendingOrder } from 'src/app/models/pending-order';
import { OrderServiceService } from 'src/app/services/order-service.service';


@Component({
  selector: 'app-orders',
  templateUrl: './orders.html',
  styleUrls: ['./orders.css']
})
export class Orders implements OnInit {

  pendingOrdersList: PendingOrder[];

  showNewOrderDialog: boolean = false;
  newOrder!: Order;

  constructor(private messageService:MessageService,private errorHandler:ErrorHandler,private orderService:OrderServiceService) {
    this.pendingOrdersList = new Array<PendingOrder>();
   }

  ngOnInit(): void {
    if (this.newOrder === null){
      this.newOrder = new Order();
    }
    this.loadPendingOrders();
  }

  private loadPendingOrders() {
    this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Customers' });
    this.orderService.getPendingOrders().subscribe(
      {
        next: (dataset: PendingOrder[])=> {
          this.pendingOrdersList = dataset;
          this.messageService.clear;
        },
        error: e=>this.handleError(e)
    });
  }

  public clickNewOrderDialog() {
    this.newOrder = new Order();
    this.showNewOrderDialog = true;
  }

  public createNewOrderDialogClick() {
  this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Adding Product' });
    const customerToUpload: Order = this.newOrder;
    this.orderService.setOrder(customerToUpload).subscribe(
    {
      next: () => this.loadPendingOrders(),
      error: (e:any)=>this.handleError(e)
    });
    this.showNewOrderDialog = false;
  }

  private handleError(errorMsg: string) {
    this.messageService.clear();
    this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
  }
}
