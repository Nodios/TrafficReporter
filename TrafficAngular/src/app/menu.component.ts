import { Component } from '@angular/core';

import { CausesService } from './causes.service';
import { CommunicationService } from './communication.service';

import { Cause } from './causes';

const CAUSES: Cause[] = [{id:1,name:'požar',data_uri:'s'},{id:2,name:'policija',data_uri:'s'}];


@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
  })

  export class MenuComponent{

    causes:Cause[]=CAUSES; 

    constructor(private causesService: CausesService,
      private communicationService: CommunicationService) {/*
        this.causesService.getCauses().then(data => this.causes = data);*/
       }

  }
  