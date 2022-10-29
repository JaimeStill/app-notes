import {
    Component,
    Input,
    OnChanges,
    SimpleChanges
} from '@angular/core';

import {
    FormGroup,
    Validators
} from '@angular/forms';

import {
    debounceTime,
    distinctUntilChanged
} from 'rxjs';

import {
    ApiValidator,
    EntityApi
} from '../../services';

import { Product } from '../../models';

@Component({
    selector: 'product-form',
    templateUrl: 'product.form.html'
})
export class ProductForm<T extends Product> implements OnChanges {
    @Input() api: EntityApi<T>;
    @Input() form: FormGroup;
    @Input() nameLabel: string = 'Name';
    @Input() creatorLabel: string = 'Creator';
    @Input() productCodeLabel: string = 'Product Code';
    @Input() releasedLabel: string = 'Date Released';

    constructor(
        private validator: ApiValidator
    ) { }

    get creator() { return this.form.get('creator') }
    get dateReleased() { return this.form.get('dateReleased') }
    get name() { return this.form.get('name') }
    get productCode() { return this.form.get('productCode') }
    get stock() { return this.form.get('stock') }

    async ngOnChanges(changes: SimpleChanges): Promise<void> {
        if (changes.form)
            await this.validator.registerValidator(
                this.api.validateName,
                this.form,
                this.name
            )
    }
}