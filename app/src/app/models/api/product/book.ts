import {
    FormBuilder,
    FormGroup,
    Validators
} from '@angular/forms';

import {
    GenerateProductForm,
    Product
} from './product';

export class Book extends Product {
    pages: number;
    publisher: string;
}

export const GenerateBookForm = (b: Book, fb: FormBuilder): FormGroup =>
    fb.group({
        ...(GenerateProductForm(b, fb)).controls,
        pages: [b?.pages ?? 1, [
            Validators.required,
            Validators.min(1)
        ]],
        publisher: [b?.publisher ?? '', Validators.required]
    })