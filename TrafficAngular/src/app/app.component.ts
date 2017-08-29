import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  template: `
  <nav>
  <a routerLink="/menu">Menu</a>
  <router-outlet></router-outlet>
  </nav>
`
})
export class AppComponent {
}
