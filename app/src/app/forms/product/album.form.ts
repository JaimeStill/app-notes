import {
    Album,
    GenerateAlbumForm,
    StorageForm
} from '../../models';

import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AlbumApi } from '../../services';

@Component({
    selector: 'album-form',
    templateUrl: 'album.form.html',
    providers: [ AlbumApi ]
})
export class AlbumForm extends StorageForm<Album> {
    constructor(
        protected fb: FormBuilder,
        public albumApi: AlbumApi
    ) {
        super(fb, GenerateAlbumForm, albumApi);
    }

    get recordLabel() { return this.form?.get('recordLabel') }
}