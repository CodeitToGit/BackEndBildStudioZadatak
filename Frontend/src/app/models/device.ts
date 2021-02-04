import { DeviceType } from './deviceType';

export class Device {
    id: number;
    name: string;
    deviceTypeId: number;
    deviceType: DeviceType;
}