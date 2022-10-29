import {
    FormBuilder,
    FormGroup,
    Validators
} from '@angular/forms';

import {
    GenerateProductForm,
    Product
} from './product';

export class Album extends Product {
    recordLabel: string;
}

export const GenerateAlbumForm = (a: Album, fb: FormBuilder): FormGroup =>
    fb.group({
        ...(GenerateProductForm(a, fb)).controls,
        recordLabel: [a?.recordLabel ?? '', Validators.required]
    })