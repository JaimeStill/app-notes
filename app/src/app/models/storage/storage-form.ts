import {
    Directive,
    EventEmitter,
    Input,
    OnChanges,
    Output,
    SimpleChanges
} from '@angular/core';

import {
    FormBuilder,
    FormControl,
    FormGroup
} from '@angular/forms';

import { Entity } from '../api';
import { EntityApi } from '../../services';
import { IStorage } from './istorage';

interface StoredControl {
    value: any,
    control: FormControl
}

type StoredControls = Record<string, StoredControl>;

@Directive()
export abstract class StorageForm<T extends Entity> implements OnChanges {
    private controls: StoredControls = {};

    form: FormGroup;
    storage: IStorage<T>;

    @Input() data: T;
    @Output() saved = new EventEmitter<T>();

    constructor(
        protected fb: FormBuilder,
        protected generator: (e: T, fb: FormBuilder) => FormGroup,
        public api: EntityApi<T>
    ) { }

    protected registerControl = (key: string, control: FormControl) =>
        this.controls[key] = <StoredControl>{ value: control.value, control };

    protected setup: () => Promise<void> | null;

    protected init = () => {
        this.storage = this.api.generateStorage(this.data);

        const value = this.storage.hasState
            ? this.storage.get()
            : this.data;

        this.form = this.generator(value, this.fb);

        this.form
            .valueChanges
            .subscribe((e: T) => this.storage.set(e));
    }

    async ngOnChanges(changes: SimpleChanges): Promise<void> {
        if (changes.data) {
            this.init();

            if (this.setup)
                await this.setup();
        }
    }

    reset = () => {
        this.form.reset(this.data);
        
        this.storage.clear();

        for (const key in this.controls)
            this.controls[key].control.setValue(this.controls[key].value);
    }

    save = async (): Promise<void> => {
        if (this.form?.valid) {
            const res = await this.api.save(this.form.value);

            if (res) {
                this.reset();
                this.saved.emit(res);
            }
        }
    }
}