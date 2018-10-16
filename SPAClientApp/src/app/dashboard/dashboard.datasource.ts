import {DataSource} from '@angular/cdk/collections';
import {MatPaginator, MatSort} from '@angular/material';
import {map} from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { Asset } from '../Model/Asset';

export class DataTableItem {
  AssetId: any;
  MimeType: any;
  FileName: any;
  CreatedBy: any;
  Country: any;
  Email: any;
  Description: any
}


export class DashboardDataSource extends DataSource<DataTableItem> {
  public data: DataTableItem[] = [];

  constructor(private paginator: MatPaginator,
              private sort: MatSort) {
    super();
  }

  connect(): Observable<DataTableItem[]> {
    const dataMutations = [
      observableOf(this.data),
      this.paginator.page,
      this.sort.sortChange
    ];

    this.paginator.length = this.data.length;

    return merge(...dataMutations).pipe(map(() => {
      return this.getPagedData(this.getSortedData([...this.data]));
    }));
  }

  disconnect() {
  }

  private getPagedData(data: DataTableItem[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  private getSortedData(data: DataTableItem[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'File name':
          return compare(a.FileName, b.FileName, isAsc);
        case 'Created by':
          return compare(+a.CreatedBy, b.CreatedBy, isAsc);
        default:
          return 0;
      }
    });
  }
}

function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
