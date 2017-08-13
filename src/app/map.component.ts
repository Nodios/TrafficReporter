import { Component, OnInit } from '@angular/core';

import { Problem } from './problem';

let PROB: Problem[]=[
    {cause:1, lat:45.5494748,lng:17.3905747},
    {cause:2, lat:45.5494748,lng:17.3005747},
    {cause:3, lat:45.5494748,lng:18.7005747}
];

@Component({
  selector: 'map',
  template: `
  <agm-map [latitude]="lat"
   [longitude]="lng" [streetViewControl]="false">
 
  <agm-marker *ngFor="let problem of Problems" 
  [latitude]="problem.lat" [longitude]="problem.lng" 
  [iconUrl]="'https://cdn0.iconfinder.com/data/icons/fatcow/32x32/shuriken.png'"
  >
  </agm-marker>
</agm-map>
<!--{{lat}} ###### {{lng}} -->
  `,
  styleUrls: ['./map.component.css']
})

export class MapComponent implements OnInit {
Problems = PROB;
  lat: number;
  lng: number;

  setPosition(position){
this.lat = position.coords.latitude;
this.lng = position.coords.longitude;
  }

    ngOnInit(): void {
        if(navigator.geolocation){
            navigator.geolocation.getCurrentPosition(this.setPosition.bind(this));
        }
  }
}