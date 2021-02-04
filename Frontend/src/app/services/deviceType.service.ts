import { DeviceType } from './../models/deviceType';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HandleError } from '../helpers/errorHandler';


@Injectable({
    providedIn: 'root'
})
export class DeviceTypeService {

    constructor(private http: HttpClient) { }

    getDeviceTypeById(id: number) {
        return this.http.get(`${environment.apiUrl}/deviceTypes/` + id).pipe(catchError(HandleError));
    }

    getAllDeviceTypes() {
        return this.http.get(`${environment.apiUrl}/deviceTypes/`).pipe(catchError(HandleError));
    }

    createOrUpdateDeviceType(deviceType: DeviceType) {
        return this.http.post(`${environment.apiUrl}/deviceTypes/`, deviceType).pipe(catchError(HandleError));
    }

    deleteDeviceType(id: number) {
        return this.http.delete(`${environment.apiUrl}/deviceTypes/` + id).pipe(catchError(HandleError));
    }

}