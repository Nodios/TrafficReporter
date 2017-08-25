import {Component, Input} from '@angular/core';
declare var google:any;

import {CommunicationService } from './communication.service';

@Component({
    selector: 'direction',
    templateUrl: './direction.component.html',
    styleUrls: ['./direction.component.css']
})

export class DirectionComponent{
    
 public directionsService: any;   // za traženje rute

    constructor(private communicationService: CommunicationService){
        this.directionsService = new google.maps.DirectionsService();
    }

  @Input()  origin: string;
  @Input()  destination: string;

    sendToMap(){
        var self = this;
        let request = {
            origin: this.origin,
            destination: this.destination,
            travelMode: google.maps.TravelMode['DRIVING']
          }
          this.directionsService.route(request, function(response, status) {
            if (status == 'OK') 
                self.communicationService.sendDirections(response);
          });

    }
}

