import { Component, OnInit, ElementRef  } from '@angular/core';
declare var google:any;

import { ReportService } from './report.service';
import { CommunicationService} from './communication.service';

import { Report } from './report';
import { Markers } from './marker'

let PROB: Report[]=[
    {Id:"s", Cause:1, Lattitude:45.5494748,Longitude:17.3905747,Rating:1,Direction:3,DateCreated:"11-11-2017"},
    {Id:"d", Cause:2, Lattitude:45.5494748,Longitude:17.3005747,Rating:1,Direction:3,DateCreated:"11-11-2017"},
    {Id:"f", Cause:3, Lattitude:45.5494748,Longitude:18.7005747,Rating:1,Direction:3,DateCreated:"11-11-2017"}
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
  tracker: any;
 public map:any;            //  za dohvaćanje google map instance
 public directionsDisplay: any;   // za prikazivanje rute
 public search: any;        //  za dohvaćanje google searchbox instance
 reports: Report[] = [];

  constructor(private elementRef: ElementRef,
  private reportService: ReportService,
  private communicationService: CommunicationService) {
    this.communicationService.activator$.subscribe(
      data =>{
        this.updateReports(this.map,this);
      }
    );

    this.communicationService.directions$.subscribe(
      data =>{
      this.directionsDisplay.setDirections(data);
      }
    )
   }


initMap(position):void {
  let selfRef = this;     
  
        this.lat = position.coords.latitude;
        this.lng = position.coords.longitude;
        this.map = new google.maps.Map(this.elementRef.nativeElement.children[0], {
        //this.map = new google.maps.Map(document.getElementById('map'),{
          zoom: 10,
          center: this,
          streetViewControl: false,
          mapTypeControl: false,
        });
       /* this.search = new google.maps.places.SearchBox(this.elementRef.nativeElement.children[1]);
        this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(this.elementRef.nativeElement.children[1]); */
        
        this.directionsDisplay = new google.maps.DirectionsRenderer();

        this.directionsDisplay.setMap(this.map);

      
        this.marker =new Markers();
        this.Problems.forEach(problem => {
          this.marker.create(this.map, problem);
        });


        this.map.addListener('bounds_changed', function() {  // usmjerava searchbox da nudi lokacije bliže onima koje gledamo na mapi
          let bounds = selfRef.map.getBounds();
        //  selfRef.search.setBounds(bounds);
 

          selfRef.reportService.getReports(bounds.b.b, bounds.f.b, bounds.b.f, bounds.f.f)    // dohvati reportove 
          .then(report => {                     // te obriši
            selfRef.marker.empty();             // stare markere
            report.forEach(function(rep) {      // i dodaj nove
             selfRef.marker.create(selfRef.map,rep);
            });
        });
      });

     /*   this.search.addListener('places_changed',function(){     // povezuje searchbox s mapom
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
        });  */
         
    //     this.reportService.delete("3f1b1071-44e3-4551-870a-3d6a2d7e0534");  - dokazano radi
  /*   this.reportService.getReports()
         .then(report => {
           report.forEach(function(rep) {
            selfRef.marker.create(selfRef.map,rep);
           // console.log(rep); 
           });

      setInterval(this.updateReports,15000, this.map, this); */
 }



updatePosition(self: any){
  navigator.geolocation.getCurrentPosition(self.setPosition.bind(self));
}

setPosition(position){
  this.lat = position.coords.latitude;
  this.lng = position.coords.longitude;
  this.map.setCenter(this);
}

trackingToggle(){
  if(!this.tracker){
    this.tracker = setInterval( this.updatePosition,1000, this);
  }
  else{
    clearInterval(this.tracker); this.tracker=undefined;
  }
}
/*
activateStandingMode(){

  if(this.buttontext == "Stationary mode"){
    this.buttontext = "Running mode";
    
  }
  else
    this.buttontext = "Stationary mode";
}
*/

menuToggle(){
  this.communicationService.menuHiddenState=!this.communicationService.menuHiddenState;
}

updateReports(map: any, selfRef: any):void{
   let a = map.getBounds()
   selfRef.reportService.getReports(a.b.b, a.f.b, a.b.f, a.f.f)    // dohvati reportove 
   .then(report => {                            // te obriši
     selfRef.marker.empty();                    // stare markere
     report.forEach(function(rep) {             // i dodaj nove
      selfRef.marker.create(selfRef.map,rep);
     });
    });
}

    ngOnInit(): void {
        if(navigator.geolocation){
            navigator.geolocation.getCurrentPosition(this.initMap.bind(this));
        }
         // console.log(this.elementRef);
  }
}