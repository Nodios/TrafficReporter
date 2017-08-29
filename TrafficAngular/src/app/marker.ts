// import { OnInit } from '@angular/core';
declare var google:any;

import { Report } from './report';

import { Cause } from './causes';

export class Markers /* implements OnInit */ {

static Collection = [];

    
   constructor(private causes: Cause[]){}
   

    // Add a new marker to map (as described in report)
    create(map:any, report: Report){
    let pos = {lat: report.Lattitude,lng:report.Longitude};
    //console.log('Cause:'+Math.log2(report.Cause));console.log('Rating:'+report.Rating);
    let image = {url: this.causes[Math.log2(report.Cause)].IconUri, scaledSize: new google.maps.Size(40,40)}
        Markers.Collection[Markers.Collection.length] = new google.maps.Marker({
          position: pos,
          map: map,
          icon: image
        });
    }

    // Remove all markers from the map
    empty(): void{
        Markers.Collection.forEach(marker => {
            marker.setMap(null);
        });
        Markers.Collection=[];  // 
        
    }

/*  ngOnInit(): void {
      // what to do here? ... Process some starting info and call javascript methods. 
  }*/
}