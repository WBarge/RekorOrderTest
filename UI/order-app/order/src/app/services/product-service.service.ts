import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ErrorHandler } from '../helpers/error-handler';
import { Product } from '../models/product';

@Injectable()
export class ProductServiceService {

  private productUrl:string = "http://localhost:32549/api/product";

  constructor(private http: HttpClient,private errorHandler:ErrorHandler) { }

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl).pipe(
      catchError((error)=>this.errorHandler.errorHandler(error))
    );
  }

  public setProduct(product: Product): Observable<Product> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post<Product>(this.productUrl, product, httpOptions).pipe(
        catchError(this.errorHandler.errorHandler)
      );
  }

}
