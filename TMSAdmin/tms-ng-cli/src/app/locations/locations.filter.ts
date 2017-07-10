import { Injectable, Pipe, PipeTransform } from '@angular/core';
import { Location } from 'app/locations/locations.model'; 
import { LocationsService } from 'app/locations/locations.service';  

@Pipe({
    name: 'LocationsPageFilter'
})
@Injectable()
export class LocationsPageFilter implements PipeTransform {
    transform(Locations: Location[], field: string, value: string): any[] {
        if (!Locations) return [];
        return Locations.filter(location => Number(location.pageNumber) == Number(value))[0].lst; 
    }
}