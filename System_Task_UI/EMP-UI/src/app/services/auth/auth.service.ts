import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from 'src/app/Entities/login-model';
import { TokenModel } from 'src/app/Entities/token-model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl:string = 'https://localhost:7027/';
  loginApiUrl:string = 'api/auth/login';
  constructor(private httpService: HttpClient) { }

  public GetToken(model: LoginModel) : Observable<TokenModel>{
    return this.httpService.post<TokenModel>(this.baseUrl+this.loginApiUrl, model);
  }

  public IsLoggedIn():Boolean{
    return localStorage.getItem('token') != '';
  }
  public GetLocalToken():any{
      return localStorage.getItem('token')
  }
}
