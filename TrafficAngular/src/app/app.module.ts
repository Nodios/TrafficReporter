import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule }    from '@angular/http';

import { AppComponent } from './app.component';
import { MapComponent } from './map.component';
import { CausesComponent} from './causes.component';
import { MenuComponent} from './menu.component';

import { DirectionComponent} from './direction.component'

import { ReportService} from './report.service';
import {CommunicationService } from './communication.service';
import { CausesService} from './causes.service';

import { RouterModule }   from '@angular/router';


import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    CausesComponent,
    MenuComponent,
    DirectionComponent
  ],
  imports: [
    HttpModule,
    BrowserModule,
    FormsModule
  ],
  providers: [ReportService,CommunicationService, CausesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
