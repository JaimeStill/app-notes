import {
    Component,
    EventEmitter,
    Input,
    Output
} from '@angular/core';

import { Product } from '../../models';

@Component({
    selector: 'product-card',
    templateUrl: 'product-card.component.html'
})
export class ProductCardComponent<T extends Product> {
    @Input() product: T;

    @Output() edit = new EventEmitter<T>();
    @Output() remove = new EventEmitter<T>();
    @Output() view = new EventEmitter<T>();
}