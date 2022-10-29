import { ProductDialogs } from './product';
import { ConfirmDialog } from './confirm';

export const Dialogs = [
    ...ProductDialogs,
    ConfirmDialog
];

export * from './product';
export * from './confirm';