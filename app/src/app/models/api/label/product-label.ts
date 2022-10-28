import { Label } from './label';
import { Product } from '../product';

export class ProductLabel extends Label {
    productId: number;

    product?: Product;
}