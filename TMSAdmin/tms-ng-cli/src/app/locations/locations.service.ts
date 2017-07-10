import { Compiler, Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
//import 'rxjs/add/operator/map'
import { Observable } from 'rxjs/Rx';
import { Location } from 'app/locations/locations.model'; 
import { Configuration } from 'app/app.constants';  

const LOCATIONS: Location[] = [];

@Injectable()
export class LocationsService {

    private actionUrl: string;
    private headers: Headers;

    constructor(private _compiler: Compiler, private _http: Http, private _configuration: Configuration) {
        this._compiler.clearCache();
        this.actionUrl = _configuration.ServerWithApiUrl + "/Location/List"; 
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');
    }

    private getHeaders() { 
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        return headers;
    }

    GetByPageNumber(pageNumber: number): Observable<Location[]> { 
        let locations$ = this._http
            .get(`${this.actionUrl}`, { headers: this.getHeaders() })
            .map(response => response.json() as Location[]) 
            .catch(this.handleError);  // HERE: This is new!
        return locations$;
    }

    GetAll(): Observable<Location[]> { 
        //let locations$ = this._http
        //    .get(`${this.actionUrl}`, { headers: this.getHeaders() })
        //    .map(mapLocations);  

        let locations$ = this._http
            .get(`${this.actionUrl}`, { headers: this.getHeaders() })
            .map(response => response.json() as Location[]) 
            .catch(this.handleError);   

        return locations$;
    } 

    private clone(object: any) { 
        return JSON.parse(JSON.stringify(object));
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}

function mapLocations(response: Response): Location[] {
    // The response of the API has a results
    // property with the actual results  
    return response.json().results.map(toLocation); 
    //return response.json().results.map();
}

function toLocation(r: any): Location {
    //let location = <Location>({
    //    pageNumber: r.pageNumber
    //}); 

    let location = <Location>({
        pageNumber: r.pageNumber,
        lst: new r.lst({
            locality_code : r.lst.locality_code,
            location_code : r.lst.location_code,
            dest_code : r.lst.dest_code,
            country_code : r.lst.country_code,
            location_name : r.lst.location_name,
            locality_desc : r.lst.locality_desc,
            dest_desc : r.lst.dest_desc,
            country_desc: r.lst.country_desc
             }
             
        )
    }); 
    return location;
}