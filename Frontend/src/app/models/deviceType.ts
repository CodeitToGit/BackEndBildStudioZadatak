import { DeviceFeature } from './deviceFeature';

export interface DeviceType {
    id: number;
    name: string;
    parentId: number;
    parent: DeviceType;
    features: DeviceFeature[];
}