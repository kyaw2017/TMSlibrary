import { Component, OnInit } from '@angular/core';
import { Location } from 'app/locations/locations.model';
import { Configuration } from 'app/app.constants'; 
import { LocationsService } from 'app/locations/locations.service'; 

@Component({
    selector: 'app-locations',  
    providers: [LocationsService, Configuration],
    templateUrl: './locations.component.html',
    styleUrls: ['./locations.component.css']
})

export class LocationsComponent implements OnInit {
    locations: Location[] = [];
    errorMessage: string = '';

    constructor(private locationsService: LocationsService) { }

    ngOnInit() {  
        this.locationsService
            .GetAll()
            .subscribe(
         /* happy path */ p => this.locations = p,
         /* error path */ e => this.errorMessage = e);
    }
}


//export class LocationsComponent implements OnInit {
//    locationItems: Location[] = [];
//    errorMessage: string = '';

//    constructor(private locationService: DataService) { }

//    ngOnInit() {  
//        this.locationService
//            .GetAll()
//            .subscribe(
///* success */ p => this.locationItems = p,
///* error */ e => this.errorMessage = e);
//    }
//}

