import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AnimalsService } from '../api/services';
import { ApiConfiguration } from '../api/api-configuration';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected readonly title = signal('My-app');

  private animalsService = inject(AnimalsService);
  private apiConfiguration = inject(ApiConfiguration);

  ngOnInit() {
    this.apiConfiguration.rootUrl = 'http://localhost:5204';
    this.animalsService.apiAnimalsGet().then(animals => {
      console.log(animals);
    });
  }
}
