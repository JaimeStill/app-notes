import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EntityApi } from './base';
import { QueryGeneratorService } from '../core';
import { Album } from '../../models';

@Injectable({
    providedIn: 'root'
})
export class AlbumApi extends EntityApi<Album> {
    constructor(
        protected generator: QueryGeneratorService,
        protected http: HttpClient
    ) {
        super('album', generator, http);
    }
}