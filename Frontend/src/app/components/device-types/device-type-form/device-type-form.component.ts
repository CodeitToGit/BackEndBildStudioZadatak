import { DeviceFeature } from './../../../models/deviceFeature';
import { DeviceTypeService } from './../../../services/deviceType.service';
import { DeviceType } from './../../../models/deviceType';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-device-type-form',
  templateUrl: './device-type-form.component.html',
  styleUrls: ['./device-type-form.component.css']
})
export class DeviceTypeFormComponent implements OnInit {

  deviceType: DeviceType = {
    id: 0,
    name: '',
    parentId: null,
    parent: null,
    features: []

  };

  deviceTypes: DeviceType[] = [];

  newFeature = '';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: DeviceTypeService,
    private toasty: ToastrService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(p => {
      const deviceTypeId = p['id'];
      if (deviceTypeId) {
        this.service.getDeviceTypeById(deviceTypeId).subscribe((type: DeviceType) => this.deviceType = type);
      }
      this.service.getAllDeviceTypes().subscribe((deviceTypes: DeviceType[]) => {
        if (deviceTypeId) {
          this.deviceTypes = deviceTypes.filter(t => t.id != deviceTypeId);
        } else {
          this.deviceTypes = deviceTypes;
        }
      });
    });

  }

  createDeviceType() {
    console.log('this.deviceType', this.deviceType);
    this.service.createOrUpdateDeviceType(this.deviceType).subscribe(() => {
      this.toasty.success('Success!');
      this.router.navigateByUrl('/devicetypes');
    });
  }

  addFeature() {
    const feature = new DeviceFeature();
    feature.name = this.newFeature;
    feature.deviceTypeId = this.deviceType.id;
    this.deviceType.features.push(feature);
    this.newFeature = '';
  }

  removeFeature(index: number) {
    this.deviceType.features.splice(index, 1);
  }
}

