import {
  Component,
  OnDestroy,
  OnInit
} from '@angular/core';

import {
  Album,
  QuerySource
} from '../../models';

import {
  AlbumDialog,
  ConfirmDialog
} from '../../dialogs';

import { MatDialog } from '@angular/material/dialog';
import { AlbumApi } from '../../services';

@Component({
  selector: 'home-route',
  templateUrl: 'home.route.html'
})
export class HomeRoute implements OnInit, OnDestroy {
  albumSrc: QuerySource<Album>;

  constructor(
    private dialog: MatDialog,
    public albumApi: AlbumApi
  ) { }

  ngOnInit(): void {
    this.albumSrc = this.albumApi.query();
  }

  ngOnDestroy(): void {
    this.albumSrc?.unsubscribe();
  }

  add = () => this.dialog.open(AlbumDialog, {
    data: <Album>{},
    disableClose: true
  })
    .afterClosed()
    .subscribe((res: Album) => res && this.albumSrc.refresh());

  edit = (album: Album) => this.dialog.open(AlbumDialog, {
    data: Object.assign(<Album>{}, album),
    disableClose: true
  })
    .afterClosed()
    .subscribe((res: Album) => res && this.albumSrc.refresh());

  remove = (album: Album) => this.dialog.open(ConfirmDialog, {
    data: {
      title: `Delete Album?`,
      content: `Are you sure you want to delete Album ${album?.name}`
    },
    autoFocus: false,
    disableClose: true
  })
    .afterClosed()
    .subscribe(async (result: boolean) => {
      if (result) {
        const res = await this.albumApi.remove(album);
        res && this.albumSrc.refresh();
      }
    })

  view = (album: Album) => window.open(album.link, '_blank');
}
