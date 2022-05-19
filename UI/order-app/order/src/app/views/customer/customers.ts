import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { CustomerServiceService } from 'src/app/services/customer-service.service';
import { ErrorHandler } from 'src/app/helpers/error-handler';
import { Customer } from 'src/app/models/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.html',
  styleUrls: ['./customers.css']
})
export class Customers implements OnInit {

  customerList: Customer[];

  showNewCustomerDialog: boolean = false;
  newCustomer!: Customer;

  constructor(private messageService:MessageService, private errorHandler:ErrorHandler,private customerService:CustomerServiceService) { 
    this.customerList = new Array<Customer>();
  }

  public ngOnInit(): void {
    if (this.newCustomer === null){
      this.newCustomer = new Customer();
    }
    this.loadCustomers();
  }

  private loadCustomers() {
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

  public clickNewCustomerDialog() {
      this.newCustomer = new Customer();
      this.showNewCustomerDialog = true;
  }

  public createNewCustomerDialogClick() {
    this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Adding Product' });
      const customerToUpload: Customer = this.newCustomer;
      this.customerService.setCustomer(customerToUpload).subscribe(
      {
        next: () => this.loadCustomers(),
        error: (e:any)=>this.handleError(e)
      });
      this.showNewCustomerDialog = false;
  }

  private handleError(errorMsg: string) {
    this.messageService.clear();
    this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
  }




}
