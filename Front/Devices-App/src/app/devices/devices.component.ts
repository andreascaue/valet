import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {

  public devices: any = [];
  public devicesFiltered: any = [];

  widthImage: number = 50;
  marginImagem: number = 2;
  showImage: boolean = true;
  private _filterList: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getDevices();
  }

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.devicesFiltered = this.filterList ? this.filterDevices(this.filterList) : this.devices;
  }

  filterDevices(filterby: string): any {

    console.log(this.devices);

  filterby = filterby.toLocaleLowerCase();
    return this.devices.filter(
    (device : any) => device.deviceName.toLocaleLowerCase().indexOf(filterby) !== -1 ||
     device.details.toLocaleLowerCase().indexOf(filterby) !== -1
    )
  }

  changeImage() {
    this.showImage = !this.showImage;
  }

  clearSearch() {
    this.filterList = '';
  }

  public getDevices(): void {
    this.http.get('http://localhost:5000/Devices').subscribe(
      response => {
        this.devices = response;
        this.devicesFiltered = this.devices;
      },
      error => console.log(error)
    );
  }

}
