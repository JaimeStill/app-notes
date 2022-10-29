import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EntityApi } from './base';
import { QueryGeneratorService } from '../core';
import { Book } from '../../models';

@Injectable({
    providedIn: 'root'
})
export class BookApi extends EntityApi<Book> {
    constructor(
        protected generator: QueryGeneratorService,
        protected http: HttpClient
    ) {
        super('book', generator, http);
    }
}