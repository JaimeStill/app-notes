import {
    FormBuilder,
    FormGroup,
    Validators
} from '@angular/forms';

export abstract class Entity {
    id: number;
    url: string;
    name: string;
    dateCreated: Date;
    lastModified: Date;
}

export const GenerateEntityForm = <T extends Entity>(e: T, fb: FormBuilder): FormGroup =>
    fb.group({
        id: [e?.id ?? 0],
        url: [e?.url ?? ''],
        name: [e?.name ?? '', Validators.required],
        dateCreated: [e?.dateCreated ?? ''],
        lastModified: [e?.lastModified ?? '']
    })