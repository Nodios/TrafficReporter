import { Component } from '@angular/core';

import { Report } from './report';

import { ReportService } from './report.service';
import {CommunicationService } from './communication.service';


const CAUSES: number[] = [1,2,4,8,16];

@Component({
  selector: 'causes',
  templateUrl: './causes.component.html',
  styleUrls: ['./causes.component.css']
})

export class CausesComponent{
causes = CAUSES;
currentCause;

constructor(
      private problemService: ReportService,
      private communicationService: CommunicationService
    ) {}

onSelect(cause: number){
    this.currentCause = cause;
 navigator.geolocation.getCurrentPosition(this.postProblem.bind(this));
}



 postProblem(position){
   let report = new Report;
   report.Cause=this.currentCause;
   report.Lattitude=position.coords.latitude;
   report.Longitude=position.coords.longitude;
   report.DateCreated= new Date().toUTCString();
   //console.log(report);
    this.problemService.createReport(report)
    .then(data =>{ console.log(data);});
    this.communicationService.activate(true);
  }
}
