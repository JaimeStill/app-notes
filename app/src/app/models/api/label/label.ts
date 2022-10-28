import { Entity } from '../base';

export class Label extends Entity {
    type: string;
    description: string;
    foreground: string;
    background: string;
}