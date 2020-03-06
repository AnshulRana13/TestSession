import { Component, Inject } from '@angular/core';
import { DOCUMENT, LocationStrategy } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
   // styleUrls: ['./app.component.css']
})
export class AppComponent {
    public title: any;

    constructor(http: HttpClient, @Inject(DOCUMENT) private document: Document, private readonly locationStrategy: LocationStrategy) {
        let url = this.document.location.origin.toString() + '/WeatherForecast';

        let url2 = "http://dummy.restapiexample.com/api/v1/employees";
        for (let i = 0; i < 3; i++) {
            http.get(url).subscribe(result => {
                this.title = result;
            }, error => console.error(error));

            http.get(url2).subscribe(result => {
                console.info(result);
            }, error => console.error(error));
        }
    }

}
