import {
    FormBuilder,
    FormGroup,
    Validators    
} from '@angular/forms';

import {
    Entity,
    GenerateEntityForm
} from '../base';

export class Product extends Entity {
    stock: number;
    type: string;
    creator: string;
    productCode: string;
    link: string;
    image: string;
    dateReleased: Date;
}

export const GenerateProductForm = <T extends Product>(p: T, fb: FormBuilder) =>
    fb.group({
        ...(GenerateEntityForm(p, fb)).controls,
        stock: [p?.stock ?? 0, [
            Validators.required,
            Validators.min(0)
        ]],
        type: [p?.type],
        creator: [p?.creator ?? '', Validators.required],
        productCode: [p?.productCode, Validators.required],
        link: [p?.link ?? ''],
        image: [p?.image ?? ''],
        dateReleased: [p?.dateReleased ?? '', Validators.required]
    })