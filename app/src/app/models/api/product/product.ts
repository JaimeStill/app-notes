import { Entity } from '../base';

export class Product extends Entity {
    stock: number;
    type: string;
    creator: string;
    productCode: string;
    link: string;
    image: string;
    dateReleased: Date;
}