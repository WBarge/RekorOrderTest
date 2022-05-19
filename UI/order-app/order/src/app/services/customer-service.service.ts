import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { ErrorHandler } from '../helpers/error-handler';
import { Customer } from '../models/customer'; 

@Injectable()
export class CustomerServiceService {

  private customerUrl:string = "http://localhost:32549/api/customer";

  constructor(private http: HttpClient,private errorHandler:ErrorHandler) { }

  public getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.customerUrl).pipe(
      catchError((error)=>this.errorHandler.errorHandler(error))
    );
  }

  public setCustomer(customer: Customer): Observable<Customer> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post<Customer>(this.customerUrl, customer, httpOptions).pipe(
        catchError(this.errorHandler.errorHandler)
      );
  }

}
