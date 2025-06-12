import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ksiazka } from '../models/ksiazka';
import { KsiazkaBody } from '../models/ksiazka-body';

@Injectable({
  providedIn: 'root'
})
export class ListaService {

  private apiUrl = 'http://localhost:5015/api/ksiazki';
  constructor(private http: HttpClient) {}

  get(): Observable<Ksiazka[]> {
    return this.http.get<Ksiazka[]>(this.apiUrl);
  }

  getByID(id: number): Observable<Ksiazka> {
    return this.http.get<Ksiazka>(`${this.apiUrl}/${id}`);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  put(id: number, body: KsiazkaBody): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, body);
  }

  post(body: KsiazkaBody): Observable<void> {
    return this.http.post<void>(this.apiUrl, body);
  }
}
