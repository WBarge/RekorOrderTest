import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ErrorHandler } from '../helpers/error-handler';
import { PendingOrder } from '../models/pending-order';
import { Order } from '../models/order';

@Injectable()
export class OrderServiceService {
    private orderUrl:string = "http://localhost:32549/api/order";

    constructor(private http: HttpClient,private errorHandler:ErrorHandler) { }
  
    public getPendingOrders(): Observable<PendingOrder[]> {
      return this.http.get<PendingOrder[]>(this.orderUrl).pipe(
        catchError((error)=>this.errorHandler.errorHandler(error))
      );
    }
  
    public setOrder(product: Order): Observable<Order> {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json'
        })
      };
      return this.http.post<Order>(this.orderUrl, product, httpOptions).pipe(
          catchError(this.errorHandler.errorHandler)
        );
    }
}
