import { Component, OnInit } from '@angular/core';
import { Device } from 'src/app/models/device';
import { DeviceSearch } from 'src/app/models/deviceSearch';
import { DeviceService } from 'src/app/services/device.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.css']
})
export class DevicesComponent implements OnInit {

  devices: Device[] = [];
  searchModel: DeviceSearch = new DeviceSearch();

  constructor( private service: DeviceService
  ) { }

  ngOnInit(): void {
    this.populateDevices();
    this.goToPage(1);
  }

  private populateDevices() {
    this.service.getAllDevices().subscribe((devices: Device[]) => {
      console.log(devices);
      this.devices = devices;
    });
  }

  onDelete(id: number) {
    this.service.deleteDevice(id).subscribe(() => this.ngOnInit());
  }

  search() {
    this.service.searchDevice(this.searchModel).subscribe(devices => {
      console.log('devices', devices);
      this.devices = devices;
    })
  }

  goToPage(pageNumber) {
    this.searchModel.pageNumber = pageNumber;
    this.search();
  }


}
