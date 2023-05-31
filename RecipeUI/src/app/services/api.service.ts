import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  readonly apiUrl = 'https://localhost:7008/api/';
  
  constructor(private http: HttpClient) { }

  getRecipeList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl + 'recipe/all');
  }
}

