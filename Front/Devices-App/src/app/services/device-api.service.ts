import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { DeviceModel } from '../models/device.model';

@Injectable({
  providedIn: 'root'
})
export class DeviceApiService {

  apiUrl: string = environment.apiUrl;
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }

  public list() : Observable<DeviceModel> {
    return this.http.get<DeviceModel>(`${this.apiUrl}`);
  }

  public delete(deviceId: number) : Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${deviceId}`);
  }

  update(id: any, data: DeviceModel): Observable<any> {
    let API_URL = `${this.apiUrl}/${id}`;
    console.log(data)
    return this.http.put(API_URL, data, { headers: this.headers });
  }
}
