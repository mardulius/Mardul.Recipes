import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRecipe } from '../models/irecipe';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly apiUrl = 'https://localhost:7008/api/';
  
  constructor(private http: HttpClient) { }

  getRecipeList(): Observable<IRecipe[]> {
    return this.http.get<IRecipe[]>(this.apiUrl + 'recipe/all');
  }
}

