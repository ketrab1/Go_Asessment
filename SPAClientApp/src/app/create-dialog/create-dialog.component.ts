import {Component, OnInit} from '@angular/core';
import {DataService} from "../data.service";
import { Asset } from "../Model/Asset";
import { Location } from '@angular/common';

@Component({
  selector: 'app-create-dialog',
  templateUrl: './create-dialog.component.html',
  styleUrls: ['./create-dialog.component.css']
})
export class CreateDialogComponent implements OnInit {

  constructor(private dataService: DataService, private location: Location) {
  }

  asset: Asset = new Asset();

  ngOnInit() {
  }

  goBack(): void {
    this.location.back();
  }

  create(): void {
    this.dataService.addAsset(this.asset);


  }

}
