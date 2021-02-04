import { DeviceType } from './../../../models/deviceType';
import { DeviceTypeService } from './../../../services/deviceType.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Device } from 'src/app/models/device';
import { DeviceService } from 'src/app/services/device.service';

@Component({
  selector: 'app-device-form',
  templateUrl: './device-form.component.html',
  styleUrls: ['./device-form.component.css']
})
export class DeviceFormComponent implements OnInit {

  device: Device = {
    id: 0,
    name: '',
    deviceTypeId: null,
    deviceType: null
  };

  deviceTypes: DeviceType[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: DeviceService,
    private typeService: DeviceTypeService,
    private toasty: ToastrService) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      const deviceId = p['id'];
      if (deviceId) {
        this.service.getDeviceById(deviceId).subscribe((device: Device) => this.device = device);
      }
      this.typeService.getAllDeviceTypes().subscribe((deviceTypes: DeviceType[]) => {
          this.deviceTypes = deviceTypes;
      });
    });
  }

  addType(id: number) {
    this.device.deviceTypeId = id;
  }

  createDevice() {
    if (this.device.id) {
      this.service.updateDevice(this.device).subscribe(() => {
        this.toasty.success('Success!');
        this.router.navigateByUrl('/devices');
      });
    }
    else {
      this.service.addDevice(this.device).subscribe(() => {
        this.toasty.success('Success!');
        this.router.navigateByUrl('/devices');
      });
    }
  }

}
