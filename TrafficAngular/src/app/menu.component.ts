
import { Component } from '@angular/core';

import { FilterService } from './filter-service';
import { Cause } from './filter-class';

@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
  })

  export class MenuComponent{

    causes: Cause[];

    constructor(private filterService: FilterService) { }

    getCauses(): void {
      this.filterService.getCauses().then(causes => this.causes = causes);
    }
  }
  