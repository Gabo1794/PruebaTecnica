import { Injectable } from '@angular/core';
import { LoginI } from '../models/login.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private url = 'https://localhost:44314/api/login';

  constructor(private http: HttpClient) { }

  validateLogin(usuario):Observable<LoginI> {
    return this.http.post<LoginI>(this.url, usuario);
  }

}
