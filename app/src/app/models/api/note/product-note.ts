import { Note } from './note';
import { Product } from '../product';

export class ProductNote extends Note {
    productId: number;

    product?: Product;
}