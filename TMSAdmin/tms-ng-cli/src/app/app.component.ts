import { Component, Input, OnInit, ViewChild, ViewContainerRef, ComponentFactoryResolver } from '@angular/core';
import { Location } from 'app/locations/locations.model';
import { Configuration } from 'app/app.constants'; 
import { LocationsService } from 'app/locations/locations.service';



@Component({
    selector: 'app-root',
    providers: [LocationsService, Configuration],
    templateUrl: 'app.component.html', 
    styleUrls: ['app.component.css']
})

export class AppComponent implements OnInit {
    @Input() locations: Array<Location>;
    //locations: Location[] = [];
    errorMessage: string = '';
    constructor(private locationsService: LocationsService) { }

    ngOnInit() { 
        this.locationsService
             .GetByPageNumber(1)
            //.GetAll()
            .subscribe(
         /* happy path */ p => this.locations = p,
         /* error path */ e => this.errorMessage = e);
    }
}