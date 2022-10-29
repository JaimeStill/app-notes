import {
    MatDialogRef,
    MAT_DIALOG_DATA
} from '@angular/material/dialog';

import {
    Component,
    Inject
} from '@angular/core';

import { Album } from '../../models';

@Component({
    selector: 'album-dialog',
    templateUrl: 'album.dialog.html'
})
export class AlbumDialog {
    constructor(
        private dialog: MatDialogRef<AlbumDialog>,
        @Inject(MAT_DIALOG_DATA) public album: Album
    ) { }

    saved = (album: Album) =>
        album && this.dialog.close(album);
}