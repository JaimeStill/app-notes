import {
    Book,
    GenerateBookForm,
    StorageForm
} from '../../models';

import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BookApi } from '../../services';

@Component({
    selector: 'book-form',
    templateUrl: 'book.form.html',
    providers: [ BookApi ]
})
export class BookForm extends StorageForm<Book> {
    constructor(
        protected fb: FormBuilder,
        public bookApi: BookApi
    ) {
        super(fb, GenerateBookForm, bookApi);
    }
    
    get pages() { return this.form?.get('pages') }
    get publisher() { return this.form?.get('publisher') }
}