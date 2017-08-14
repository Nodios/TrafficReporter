import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Report } from './report';

@Injectable()
export class ReportService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private reportUrl = 'api/problem';  // URL to web api

  constructor(private http: Http) { }

  getReports(latMin: number,longMin: number,latMax: number, longMax: number): Promise<Report[]> {
    return this.http.get(this.reportUrl)
               .toPromise()
               .then(response => response.json().data as Report[])
               .catch(this.handleError);
  } 


 /* getProblem(id: number): Promise<Report> { 
    const url = `${this.reportUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as Report)
      .catch(this.handleError);
  }

    delete(id: number): Promise<void> {
    const url = `${this.reportUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  } */

  createReport(cause:number ,lat: number, long: number): Promise<Report> {
    return this.http
      .post(this.reportUrl, JSON.stringify({cause,lat,long}), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data as Report)
      .catch(this.handleError);
  }
    
/*
  updateReport(id: number): Promise<Report> {
    const url = `${this.reportUrl}/${id}`;
    return this.http
      .put(url, JSON.stringify(id), {headers: this.headers})
      .toPromise()
      .then(() => Report)
      .catch(this.handleError);
  } 
    */

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}