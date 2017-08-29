import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule }    from '@angular/http';

import { AppComponent } from './app.component';
import { MapComponent } from './map.component';
import { CausesComponent} from './causes.component';
import { MenuComponent} from './menu.component';


import { ReportService} from './report.service';
import {CommunicationService } from './communication.service';
import { CausesService} from './causes.service';

import { RouterModule }   from '@angular/router';


@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    CausesComponent,
    MenuComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    RouterModule.forRoot([
      {
        path: 'menu',
        component: MenuComponent                
      }
    ])
  ],
  providers: [ReportService,CommunicationService, CausesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
