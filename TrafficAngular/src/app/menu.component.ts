import { Component, ElementRef } from '@angular/core';

import { CausesService } from './causes.service';
import { CommunicationService } from './communication.service';

import { Cause } from './causes';


@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
  })

  export class MenuComponent{

    causes:Cause[]; 

    constructor(private causesService: CausesService, private elementRef: ElementRef,
      private communicationService: CommunicationService) {
        this.causesService.getCauses().then(data => {
          this.causes = data
          console.log(this.causes);}
        );
        
       }

  apply(){
    let j=0;
    for(let i=0; i+1<this.elementRef.nativeElement.children[0].children.length;i++)
      if(this.elementRef.nativeElement.children[0].children[i].children[0].checked)
        j+=Number(this.elementRef.nativeElement.children[0].children[i].children[0].value);   
    this.communicationService.setFilter(j);
    this.communicationService.menuStateHidden=true;
  }

  }
  