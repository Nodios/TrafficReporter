import { Component } from '@angular/core';

const CAUSES: number[] = [1,2,3,4,5];

@Component({
  selector: 'causes',
  template: `
  <div>ssss sve vrste nesreća

  <span *ngFor="let cause of causes" (click)="onSelect(cause)">
    <img src="./assets/images/{{cause}}.png">
  </span>
  </div> 

  `,
  styleUrls: ['./causes.component.css']
})

export class CausesComponent{
causes = CAUSES;

onSelect(cause: number){}
}
