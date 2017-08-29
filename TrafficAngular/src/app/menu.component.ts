
import { Component } from '@angular/core';

import { CausesService } from './causes.service';
import { Cause } from './causes';

@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
  })

  export class MenuComponent{

    causes: Cause[];

    constructor(private causesService: CausesService) { }

    getCauses(): void {
      this.causesService.getCauses().then(data => this.causes = data);
    }
  }
  