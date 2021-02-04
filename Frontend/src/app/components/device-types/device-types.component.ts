import { DeviceTypeService } from './../../services/deviceType.service';
import { Component, OnInit } from '@angular/core';
import { DeviceType } from 'src/app/models/deviceType';

@Component({
  selector: 'app-device-types',
  templateUrl: './device-types.component.html',
  styleUrls: ['./device-types.component.css']
})
export class DeviceTypesComponent implements OnInit {

  types: DeviceType[] = [];
  constructor(private service: DeviceTypeService

  ) { }

  ngOnInit(): void {
    this.populateDeviceTypes();
  }


  onDelete(id) {
    this.service.deleteDeviceType(id).subscribe( () => this.ngOnInit());
  }


  private populateDeviceTypes() {
    this.service.getAllDeviceTypes().subscribe((types: DeviceType[]) => {
      console.log(types);
      this.types = types;
    });

  }
}
