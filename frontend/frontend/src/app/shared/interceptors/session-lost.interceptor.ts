import { Injectable } from "@angular/core";
import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';

@Injectable()
export class SessionLostInterceptor implements HttpInterceptor {
  constructor(public userService: UserService, public router: Router) { }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          // 401 handled in auth.interceptor
          localStorage.clear()
          sessionStorage.clear();
        }
        return throwError(error);
      })
    );
  }
}
