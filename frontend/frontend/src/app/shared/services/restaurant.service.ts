import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Restaurant } from '../models/restaurant.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  baseURL = 'https://localhost:44335/api/restaurant/';

  constructor(private http: HttpClient) { }



  getRestaurantById(id: String): Observable<Restaurant> {
    return this.http.get<Restaurant>(`${this.baseURL}get?id=${id}`);
  }



  updateRestaurant(model:any){

    return this.http.put(this.baseURL+"update?id="+sessionStorage.getItem("restaurant"), model);
    
  }

  


}