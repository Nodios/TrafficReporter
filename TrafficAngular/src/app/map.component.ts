import { Component, OnInit, ElementRef  } from '@angular/core';
declare var google:any;

import { Report } from './report';
import { Markers } from './marker'

let PROB: Report[]=[
    {cause:1, lat:45.5494748,lng:17.3905747},
    {cause:2, lat:45.5494748,lng:17.3005747},
    {cause:3, lat:45.5494748,lng:18.7005747}
];


@Component({
  selector: 'map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})

export class MapComponent implements OnInit {
Problems = PROB;
  lat: number;
  lng: number;
  marker: Markers;

  constructor(private elementRef: ElementRef) { }

initMap(position) {
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
        this.marker =new Markers( new google.maps.Map(this.elementRef.nativeElement, {
          zoom: 10,
          center: this
        }));
        this.Problems.forEach(problem => {
          this.marker.create(problem);
        });

        setTimeout(this.marker.empty,5000);
      }

    ngOnInit(): void {
        if(navigator.geolocation){
            navigator.geolocation.getCurrentPosition(this.initMap.bind(this));
        }
         // console.log(this.elementRef);
  }
}