import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';

import {Asset} from '../Model/Asset';
import {DataService} from '../data.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  asset: Asset = new Asset();

  constructor(
    private route: ActivatedRoute,
    private dataService: DataService,
    private location: Location
  ) {
  }

  id: string


  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getAsset();

  }

  private getAsset(): void {

    this.dataService.getAsset(this.id)
      .subscribe(asset => this.asset = asset);
  }

  public delete(): void {
    this.dataService.deleteAsset(this.asset.AssetId).subscribe(() => this.goBack());
  }

  public save(): void {
    this.dataService.updateAsset(this.asset);
  }

  public goBack(): void {
    this.location.back();
  }

}
