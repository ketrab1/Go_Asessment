import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Asset } from './Model/Asset';


@Injectable({
  providedIn: 'root'
})
export class DataService {

  private assetsUrl = 'http://localhost:62677/api/Asset';
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient
  ) { }

  getAssets(): Observable<Array<Asset>> {
    return this.http.get<Array<Asset>>(this.assetsUrl);
  }

  getAsset(id: any): Observable<Asset> {
    const url = `${this.assetsUrl}/${id}`;
    return this.http.get<Asset>(url).pipe(
      catchError(this.handleError<Asset>(`getAsset id=${id}`))
    );
  }

  addAsset(asset: Asset)   {
    this.http.post<Asset>(this.assetsUrl, asset, this.httpOptions).subscribe( );
  }

  deleteAsset(id: string): Observable<Asset> {
    const url = `${this.assetsUrl}/${id}`;
    return this.http.delete<Asset>(url, this.httpOptions).pipe(
      catchError(this.handleError<Asset>('deleteAsset'))
    );
  }

  updateAsset(asset: Asset) {
    this.http.put<Asset>(this.assetsUrl, asset, this.httpOptions).subscribe();
  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }


}
