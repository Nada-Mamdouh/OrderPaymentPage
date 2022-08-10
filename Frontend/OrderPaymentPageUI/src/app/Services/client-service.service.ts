import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IClient } from '../_models/iclient';

@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  client:IClient |any = {};
  clientId: number = 1;
  getClientUrl: string|any = "https://localhost:7117/api/Clients/";
  constructor(private httpclient:HttpClient) {}
  public get(): Observable<IClient|any>{
    return this.httpclient.get(this.getClientUrl + this.clientId);
  }
}
