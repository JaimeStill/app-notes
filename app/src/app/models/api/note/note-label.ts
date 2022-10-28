import { Note } from './note';
import { Label } from '../label';

export class NoteLabel {
    id: number;
    labelId: number;
    noteId: number;

    label?: Label;
    note?: Note;
}