import { DeviceSearch } from '../models/deviceSearch';
import { Device } from '../models/device';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HandleError } from '../helpers/errorHandler';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  constructor(private http: HttpClient) { }

  getDeviceById(id: number) {
    return this.http.get(`${environment.apiUrl}/devices/` + id).pipe(catchError(HandleError));
  }

  getAllDevices() {
    return this.http.get(`${environment.apiUrl}/devices`).pipe(catchError(HandleError));
  }

  addDevice(device: Device) {
    return this.http.post<Device>(`${environment.apiUrl}/devices`, device).pipe(catchError(HandleError));
  }

  updateDevice(device: Device) {
    return this.http.put<Device>(`${environment.apiUrl}/devices`, device).pipe(catchError(HandleError));
  }

  searchDevice(deviceSearch: DeviceSearch) {
    return this.http.post<Device[]>(`${environment.apiUrl}/devices/search`, deviceSearch).pipe(catchError(HandleError));
  }

  deleteDevice(id: number){
    return this.http.delete(`${environment.apiUrl}/devices/` + id).pipe(catchError(HandleError));
  }
}
