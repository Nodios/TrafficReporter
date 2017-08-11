import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule }    from '@angular/http';
import { AgmCoreModule } from '@agm/core';

import { AppComponent } from './app.component';
import { MapComponent } from './map.component';
import { CausesComponent} from './causes.component';

import { ProblemService} from './problem.service';

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    CausesComponent
  ],
  imports: [
    HttpModule,
        AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDqsOH0wHMXPRwMWaP0X9NVUZGXCkfLarY'
    }),
    BrowserModule
  ],
  providers: [ProblemService],
  bootstrap: [AppComponent]
})
export class AppModule { }
