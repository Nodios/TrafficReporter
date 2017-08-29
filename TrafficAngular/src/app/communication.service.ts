import { Injectable }    from '@angular/core';
import { Subject }    from 'rxjs/Subject';

@Injectable()
export class CommunicationService {

  private activator = new Subject<boolean>(); 
  activator$ = this.activator.asObservable();
  activate(data: boolean) {
    this.activator.next(data);
  }

  private directions = new Subject<any>();
  directions$ = this.directions.asObservable();
  sendDirections(data: any){
    this.directions.next(data);
  }

  public menuHiddenState: boolean = true;
  }
