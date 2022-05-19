import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { IErrorMessageFromServer } from './ierror-message-from-server';

@Injectable()
export class ErrorHandler {

  public errorHandler(error: HttpErrorResponse | any) {
    let errMsg: string;
    let systemErrorMessage: IErrorMessageFromServer | undefined;
    if (error instanceof HttpErrorResponse) {
        systemErrorMessage = error.error;
        //@ts-ignore
        errMsg = `${systemErrorMessage.exceptionType} - ${systemErrorMessage.message || ''} URL Error Happened At ${error.url}`;
    } else {
        errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return throwError(systemErrorMessage ? systemErrorMessage.message : errMsg);
}
}
