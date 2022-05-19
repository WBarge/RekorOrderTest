import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { MessageService } from 'primeng/api';
import { ErrorHandler } from 'src/app/helpers/error-handler';
import { ProductServiceService } from 'src/app/services/product-service.service';

import { HttpResponse } from '@angular/common/http';
import { ProductParser } from 'src/app/models/parsers/product-parser';

@Component({
  selector: 'app-products',
  templateUrl: './products.html',
  styleUrls: ['./products.css']
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
        this.loadProducts();
    }

    private loadProducts() {
        this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Loading Products' });
        this.productService.getProducts().subscribe((dataset: Product[])=>{
          this.productList = dataset;
          this.messageService.clear;
        },
        e=>this.handleError(e));
    }

    public clickNewProductDialog() {
        if (this.newProduct == null)
            this.newProduct = new Product("","",0,0);
        this.showNewProductDialog = true;
    }

    public createNewProductDialogClick() {
      this.messageService.add({ severity: 'info', summary: 'System Message', detail: 'Adding Product' });
        const productToUpload: Product = this.newProduct;
        this.productService.setProduct(productToUpload).subscribe(
            () => this.loadProducts(),
            error => this.handleError(error)
        );
        this.showNewProductDialog = false;
    }

    private handleError(errorMsg: string) {
      this.messageService.clear();
      this.messageService.add({ severity: 'error', summary: 'Error', detail: errorMsg });
    }



}
