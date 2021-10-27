import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseURL = 'https://localhost:44335/api/types';

  constructor(private http: HttpClient) { }

  postCategory(category: Category) {
    return this.http.post(`${this.baseURL}/add`, category);
  }


  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.baseURL}/${id}`);
  }




  putCategory(category: Category,id:number) {
    return this.http.put(`${this.baseURL}/${id}`, category);
  }

  deleteCategory(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}