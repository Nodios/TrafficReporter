import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule }    from '@angular/http';

import { AppComponent } from './app.component';
import { MapComponent } from './map.component';
import { CausesComponent} from './causes.component';

import { ReportService} from './report.service';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    CausesComponent
  ],
  imports: [
    HttpModule,
    BrowserModule
  ],
  providers: [ReportService],
  bootstrap: [AppComponent]
})
export class AppModule { }
