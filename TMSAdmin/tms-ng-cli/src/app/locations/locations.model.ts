import { Component, OnInit } from '@angular/core'; 

export class Location {
    pageNumber: string;
    lst: lst[];
}

export interface lst {
    locality_code: string;
    location_code: string;
    dest_code: string;
    country_code: string;
    location_name: string;
    locality_desc: string;
    dest_desc: string;
    country_desc: string;
} 