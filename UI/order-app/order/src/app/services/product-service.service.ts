import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {map,switchMap,catchError} from 'rxjs/operators';
import { HttpResponse } from '@angular/common/http';

import { ErrorHandler } from '../helpers/error-handler';
import { ServiceLocationService } from './service-location-service';
import { Product } from '../models/product';
import { ProductParser } from '../models/parsers/product-parser';
import { ServiceLocation } from '../models/service-location';

@Injectable()
export class ProductServiceService {

  private productUrl:string = "http://localhost:32549/api/product";

  constructor(private http: HttpClient,private errorHandler:ErrorHandler, private configService:ServiceLocationService) { }

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl).pipe(
      catchError((error)=>this.errorHandler.errorHandler(error))
    );
  }

  // public getProducts(): Observable<Product[]> {
  //   return this.configService.getServiceLocation().pipe(
  //       switchMap((config: ServiceLocation) => this.handleConfigurationResultForGetProducts(config)),
  //       catchError(err => this.errorHandler.errorHandler(err))
  //   );
  // }

  private handleConfigurationResultForGetProducts(conf: ServiceLocation): Observable<Product[]> {
    return this.http.get(conf.productLocation).pipe(
        map(this.handleGetProductsResult),
        catchError(this.errorHandler.errorHandler)
    );
  }
  private handleGetProductsResult(res: any): Product[] {
    var returnValue: Product[] = ProductParser.parseResponseInToArray(res);
    return returnValue;
  }

  public setProduct(product: Product) {
    return this.configService.getServiceLocation().pipe(
        switchMap((config: ServiceLocation) => this.saveProduct(config, product)),
        catchError(err => this.errorHandler.errorHandler(err))
    );
  }
  private saveProduct(locations: ServiceLocation, product: Product) {
    return this.http.post(locations.productLocation, product).pipe(
        catchError(err => this.errorHandler.errorHandler(err))
    );
  }

}
