import {
    Component,
    Input
} from '@angular/core';

import { Product } from '../../models';

@Component({
    selector: 'product-display',
    templateUrl: 'product-display.component.html'
})
export class ProductDisplayComponent<T extends Product> {
    @Input() product: T;
}