import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { WebRequestService } from './web-request.service';
import { User } from '../models/users.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseURL = 'https://localhost:44335/api/Authenticate/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient, private webReqService: WebRequestService) { }

  login(model: any) {
    return this.http
      .post(`${this.baseURL}login`, model).pipe(
        map((response: any) => {
          const user = response;
          if (user) {
            localStorage.setItem('role', user.role_name);
            if( localStorage.getItem('role')=="Admin"){
              localStorage.setItem('token', user.token);
              sessionStorage.setItem('id', user.id);
              sessionStorage.setItem('email', user.email);
              sessionStorage.setItem('restaurant', user.restaurantID)
            }else{
              localStorage.removeItem('role');
            }
            
          }

        })
        
      );

      
  }

  getUser(id: string) {
    return this.http.get<User>(this.baseURL+"perfil?id="+id);
  }
  getUsers(){
    return this.http.get<User[]>(this.baseURL+"allusers?id="+sessionStorage.getItem("id"));
  }
  
  forgetPassword(model:any){
    return this.http.post(`${this.baseURL}forgetpassword`,model);
  }

  updateUser(id:String,model:any){
    return this.http.put(this.baseURL+"updateuser?id="+id, model);
    
  }
  
 
  loggedIn() {
    const token = localStorage.getItem('token');
    if(token!=null){
    return !this.jwtHelper.isTokenExpired(token);
    }
    return null;
  }




}