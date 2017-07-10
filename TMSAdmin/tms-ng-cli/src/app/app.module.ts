import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationRef } from '@angular/core'; 
import { CommonModule } from '@angular/common'; 
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { LocationsPageFilter } from 'app/locations/locations.filter'; 
//import { LocationsComponent } from './locations/locations.component';

@NgModule({
    declarations: [
        AppComponent,
        LocationsPageFilter 
    ],
    imports: [
        BrowserModule,
        CommonModule, 
        HttpModule
    ],
    providers: [],
    entryComponents: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule {

}
 