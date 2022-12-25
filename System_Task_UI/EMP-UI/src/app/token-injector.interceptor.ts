import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth/auth.service';

@Injectable()
export class TokenInjectorInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    request = this.addAuthToken(request);
    return next.handle(request);
  }

  addAuthToken(request: HttpRequest<any>) {
    const token = this.authService.GetLocalToken();
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`
      }
    })
  }
}
