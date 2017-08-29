import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Cause } from './causes';

@Injectable()
export class CausesService {

  
  private reportUrl = 'http://localhost:50169/api/Causes';  // URL to web api
  
  constructor(private http: Http) { }

  getCauses(): Promise<Cause[]> {
    return this.http.get(this.reportUrl)
               .toPromise()
               .then(response => response.json() as Cause[])
               .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}