import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { WebRequestService } from './web-request.service';
import { User } from '../models/users.model';


const baseURL = 'https://localhost:44335/api/Authenticate/';


const httpOptions = {
  headers: new HttpHeaders({
      'Content-Type': 'application/json'
  }),
  withCredentials: true
};

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  expired = false
 
  constructor() { }
}
