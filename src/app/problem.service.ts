import { Injectable }    from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Problem } from './problem';

@Injectable()
export class ProblemService {

  private headers = new Headers({'Content-Type': 'application/json'});
  private problemUrl = 'api/problem';  // URL to web api

  constructor(private http: Http) { }

  getProblems(latMin: number,longMin: number,latMax: number, longMax: number): Promise<Problem[]> {
    return this.http.get(this.problemUrl)
               .toPromise()
               .then(response => response.json().data as Problem[])
               .catch(this.handleError);
  } 


 /* getProblem(id: number): Promise<Problem> {
    const url = `${this.problemUrl}/${id}`;
    return this.http.get(url)
      .toPromise()
      .then(response => response.json().data as Problem)
      
      .catch(this.handleError);
  }

    delete(id: number): Promise<void> {
    const url = `${this.problemUrl}/${id}`;
    return this.http.delete(url, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  } */

  createProblem(problem: Problem): Promise<Problem> {
    return this.http
      .post(this.problemUrl, JSON.stringify(problem), {headers: this.headers})
      .toPromise()
      .then(res => res.json().data as Problem)
      .catch(this.handleError);
  }

  updateProblem(id: number): Promise<Problem> {
    const url = `${this.problemUrl}/${id}`;
    return this.http
      .put(url, JSON.stringify(id), {headers: this.headers})
      .toPromise()
      .then(() => Problem)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}