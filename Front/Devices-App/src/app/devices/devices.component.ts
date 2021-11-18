import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {

  public itensDevices: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getDevices();
  }

  public getDevices(): void {
     this.http.get('http://localhost:5000/Devices').subscribe(
       response => this.itensDevices = response,
       error => console.log(error)
     );
  }

}
