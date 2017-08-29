import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Report } from './report';

@Injectable()
export class ReportService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private reportUrl = 'http://localhost:50169/api/Report';  // URL to web api

  constructor(private http: Http) { }

  // request all reports in area defined by map bounds
  getReports( latMin: number,longMin: number,latMax: number, longMax: number, cause: number): Promise<Report[]> {
    return this.http.get(this.reportUrl+"?dx="+latMin+"&dy="+longMin+"&ux="+latMax+"&uy="+longMax+"&cause="+cause+"&pageSize=50")
               .toPromise()
               .then(response => response.json() as Report[])
               .catch(this.handleError);
  } 


  getReport(id: string): Promise<Report> { 
    const url = `${this.reportUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json() as Report)
      .catch(this.handleError);
  }


    delete(id: string): Promise<void> {
    const url = `${this.reportUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  } 

  // register a new report
  createReport(report: Report): Promise<any> {
    return this.http
      .post(this.reportUrl, report, {headers: this.headers})
      .toPromise()
      .then(response => response.json() as any)
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

    // In case any of the steps above failed
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}