import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessageService } from 'primeng/api';
import { ErrorHandler } from 'src/app/helpers/error-handler';
import { ProductServiceService } from 'src/app/services/product-service.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.html',
  styleUrls: ['./products.css'],
})
export class Products implements OnInit {
    //data for the grid
    productList: Product[];

    showNewProductDialog: boolean = false;
    newProduct!: Product;


    constructor(private messageService:MessageService, private errorHandler:ErrorHandler,private productService:ProductServiceService) {
        this.productList = new Array<Product>();
    }

    public ngOnInit(): void {
      if (this.newProduct === null){
        this.newProduct = new Product();
      }
      this.loadProducts();
    }

    private loadProducts() {
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

    public clickNewProductDialog() {
        this.newProduct = new Product();
        this.showNewProductDialog = true;
    }

    public createNewProductDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Adding Product' });
        const productToUpload: Product = this.newProduct;
        this.productService.setProduct(productToUpload).subscribe(
        {
          next: () => this.loadProducts(),
          error: (e:any)=>this.handleError(e)
        });
        this.showNewProductDialog = false;
    }

    private handleError(errorMsg: string) {
      this.messageService.clear();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }



}
