import { Component, OnInit, ElementRef  } from '@angular/core';
declare var google:any;

import { ReportService } from './report.service';
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
Problems = PROB;      // sadrži listu problema za prikazati
  lat: number;        //  <-.
  lng: number;        //  <-+ trenutne kordinate
  marker: Markers;    //  
 public map:any;            //  za dohvaćanje google map instance
 public search: any;        //  za dohvaćanje google searchbox instance

  constructor(private elementRef: ElementRef) { }


initMap(position):void {
  let selfRef = this;     
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
        console.dir(google.maps);
        this.map = new google.maps.Map(this.elementRef.nativeElement.children[0], {
          zoom: 10,
          center: this,
          streetViewControl: false,
          mapTypeControl: false
        });
        this.search = new google.maps.places.SearchBox(this.elementRef.nativeElement.children[1]);
        this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(this.elementRef.nativeElement.children[1]);
      
        this.marker =new Markers();
        this.Problems.forEach(problem => {
          this.marker.create(this.map, problem);
        });


        this.map.addListener('bounds_changed', function() {  // usmjerava searchbox da nudi lokacije bliže onima koje gledamo na mapi
          let bounds = selfRef.map.getBounds();
          selfRef.search.setBounds(bounds);
          console.log(bounds.b.b, bounds.f.b, bounds.b.f, bounds.f.f);
        });

        this.search.addListener('places_changed',function(){     // povezuje searchbox s mapom
           let places = selfRef.search.getPlaces();

          if (places.length == 0) {
            return;
          }

        let bounds = new google.maps.LatLngBounds();
        places.forEach(function(place) {
            if (!place.geometry) {
              console.log("Returned place contains no geometry");
              return;
            }

            if (place.geometry.viewport) {
              // Only geocodes have viewport.
              bounds.union(place.geometry.viewport);
            } else {
              bounds.extend(place.geometry.location);
            }
          });
        selfRef.map.fitBounds(bounds);
        });
      setInterval(this.updateReports,15000, this.map); 
      }


updateReports(map: any):void{
   let a = map.getBounds()
        console.log(a.b.b, a.f.b, a.b.f, a.f.f);
}

    ngOnInit(): void {
        if(navigator.geolocation){
            navigator.geolocation.getCurrentPosition(this.initMap.bind(this));
        }
         // console.log(this.elementRef);
  }
}