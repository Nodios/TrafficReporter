import { Component } from '@angular/core';

import { Report } from './report';

import { ReportService } from './report.service';
import { CommunicationService } from './communication.service';
import { CausesService } from './causes.service';

import { Cause } from './causes';


@Component({
  selector: 'causes',
  templateUrl: './causes.component.html',
  styleUrls: ['./causes.component.css']
})

export class CausesComponent{
causes: Cause[];
currentCause;

constructor(
      private problemService: ReportService,
      private communicationService: CommunicationService,
      private causesService: CausesService, 
    ) {
      this.causesService.getCauses()
      .then(data =>{   
        this.causes = data;
      });
  }

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
    .then(data =>{ 
      if(data==0){
        alert('We found matching report nearby and updated his rating.');
      }
    });
    this.communicationService.activate(true);
  }
}
