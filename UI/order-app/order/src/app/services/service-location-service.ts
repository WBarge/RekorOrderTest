import { Injectable } from '@angular/core';
import { HttpClient, } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ServiceLocation } from '../models/service-location';

@Injectable()

export class ServiceLocationService {
  public getServiceLocation(): Observable<ServiceLocation> {

    const hostLocation: string = "http://localhost:32549/api";

    const productPath:string = '/Product';

    var returnValue: ServiceLocation = new ServiceLocation();
    returnValue.pendingOrderLocation = hostLocation + productPath;

    return of(returnValue);
  }

}
