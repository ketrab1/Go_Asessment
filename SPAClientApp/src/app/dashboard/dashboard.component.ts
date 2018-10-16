import {Component, OnInit, ViewChild, Input} from '@angular/core';
import {MatPaginator, MatSort} from '@angular/material';
import {DashboardDataSource} from './dashboard.datasource';
import {DataService} from '../data.service';
import {DatePipe} from "@angular/common";
import {MatDialog} from '@angular/material/dialog';
import {Router} from '@angular/router';
import {CreateDialogComponent} from "../create-dialog/create-dialog.component";


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  @ViewChild(MatPaginator)
  paginator: MatPaginator;
  @ViewChild(MatSort)
  sort: MatSort;
  dataSource: DashboardDataSource;


  constructor(private dataService: DataService, private datePipe: DatePipe, private dialog: MatDialog, private router: Router) {
  }
  displayedColumns = ['FileName', 'CreatedBy', 'Actions'];

  load() {
    this.dataService.getAssets().subscribe(x => {
        let _dataSource = new DashboardDataSource(this.paginator, this.sort);
        _dataSource.data = x;
        this.dataSource = _dataSource;

      },
      error => {
        this.dataSource = new DashboardDataSource(this.paginator,
          this.sort);
        //    this.openDialog(error);
      });
  }

  create(): void {
    const dialog = this.dialog.open(CreateDialogComponent,
      {
        width: '700px',
      });
  }

  private navigateToCreate() {
    this.router.navigate(['/create'])
  }

  private navigateToDetail(assetId) {
    this.router.navigate(['/detail', assetId])
  }

  ngOnInit() {
    this.load();
    this.dataSource =
      new DashboardDataSource(this.paginator,
        this.sort);
  }
}
