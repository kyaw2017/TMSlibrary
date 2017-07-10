import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    public Server: string = 'http://localhost:8000';
    public ServerWithApiUrl = this.Server;  
}