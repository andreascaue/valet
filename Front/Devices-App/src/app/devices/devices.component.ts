import { HttpClient } from '@angular/common/http';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { retry } from 'rxjs';
import { DeviceModel } from '../models/device.model';
import { DeviceApiService } from '../services/device-api.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss'],
})
export class DevicesComponent implements OnInit {

  public devices: DeviceModel[] = [];
  public deviceItem: DeviceModel = {} as DeviceModel;
  public deviceItemEdit: DeviceModel = {} as DeviceModel;
  public devicesFiltered: any = [];
  styleMd6: string = 'col-md-6';
  styleMd12: string = 'col-md-12';
  public applyStyleDetail: string = this.styleMd12;
  public enabledDetail: boolean = false;

  widthImage: number = 50;
  marginImagem: number = 2;
  showImage: boolean = true;
  private _filterList: string = '';

  displayStyle = 'none';

  constructor(private deviceApi: DeviceApiService) {}

  ngOnInit(): void {
    this.getDevices();

  }

  public get filterList(): string {
    return this._filterList;
  }

  public set filterList(value: string) {
    this._filterList = value;
    this.devicesFiltered = this.filterList
      ? this.filterDevices(this.filterList)
      : this.devices;
  }

  filterDevices(filterby: string): any {

    filterby = filterby.toLocaleLowerCase();
    return this.devices.filter(
      (device: any) =>
        device.deviceName.toLocaleLowerCase().indexOf(filterby) !== -1 ||
        device.details.toLocaleLowerCase().indexOf(filterby) !== -1
    );
  }

  changeImage() {
    this.showImage = !this.showImage;
  }

  clearSearch() {
    this.filterList = '';
  }

  public getDevices(): void {
    this.deviceApi.list().subscribe({
      next: this.handleListResponse.bind(this),
      error: this.handleError.bind(this),
    });
  }

  deleteItem(deviceId: number) {
    let deviceItem =
      this.devices.find((c) => c.deviceID == deviceId) ?? ({} as DeviceModel);

    if (deviceItem) {
      if (confirm('Are you sure to delete ' + deviceItem.deviceName)) {
        this.deviceApi.delete(deviceId).subscribe({
          next: this.handleDeleteResponse.bind(this),
          error: this.handleError.bind(this),
        });
      }
    }
  }

  update() {
    // Validar campos vazios -- this.deviceItemEdit



    let updateItem =
      this.devices.find((c) => c.deviceID == this.deviceItemEdit.deviceID) ??
      ({} as DeviceModel);

    if (updateItem) {
      updateItem.deviceName = this.deviceItemEdit.deviceName;
      updateItem.details = this.deviceItemEdit.details;

      this.deviceApi
        .update(this.deviceItemEdit.deviceID, updateItem)
        .subscribe({
          next: this.handleUpdateResponse.bind(this),
          error: this.handleError.bind(this),
        });

      this.closePopup();
      this.getDevices();
    } else {
      alert('Error update device!');
    }
  }

  openPopup(deviceId: number) {
    Object.assign(
      this.deviceItemEdit,
      this.devices.find((c) => c.deviceID == deviceId) ?? ({} as DeviceModel)
    );

    if (this.deviceItemEdit) {
      this.displayStyle = 'block';
    } else {
      alert('Error update device!');
    }
  }
  closePopup() {
    this.displayStyle = 'none';
  }

  seeDetail(deviceId: number) {
    this.deviceItem =
      this.devices.find((c) => c.deviceID == deviceId) ?? ({} as DeviceModel);
    this.applyStyleDetail = this.styleMd6;
    this.enabledDetail = true;
  }

  closeDetail() {
    this.applyStyleDetail = this.styleMd12;
    this.enabledDetail = !this.enabledDetail;
  }

  handleListResponse(response: any) {
    this.devices = response.map(
      (item: {
        deviceID: any;
        deviceName: any;
        temperature: any;
        categoryID: any;
        details: any;
        usage: any;
        deviceStatus: any;
        date: any;
        imageURL: any;
      }) => {
        return {
          deviceID: item.deviceID,
          deviceName: item.deviceName,
          temperature: item.temperature,
          categoryID: item.categoryID,
          details: item.details,
          usage: item.usage,
          deviceStatus: item.deviceStatus,
          date: item.date,
          imageURL: item.imageURL,
        } as DeviceModel;
      }
    ) as DeviceModel[];
    this.devicesFiltered = this.devices;
  }

  handleUpdateResponse(response: any) {
    if (response.message == 'Updated') {
      alert('Device successfully updated!');
      this.getDevices();
    } else {
      alert('Error updated device!');
    }
  }

  handleDeleteResponse(response: any) {
    if (response.message == 'Deteled') {
      alert('Device successfully deleted!');
      this.getDevices();
    } else {
      alert('Error deleting device!');
    }
  }

  handleError(error: any) {
    console.error(error);
  }
}
