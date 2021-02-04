import { DeviceFormComponent } from './components/devices/device-form/device-form.component';
import { AppComponent } from './app.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DevicesComponent } from './components/devices/devices.component';
import { DeviceTypesComponent } from './components/device-types/device-types.component';
import { DeviceTypeFormComponent } from './components/device-types/device-type-form/device-type-form.component';

const routes: Routes = [
  { path: '', component: DevicesComponent},
  { path: 'devices', component: DevicesComponent},
  { path: 'devices/new', component: DeviceFormComponent},
  { path: 'devices/edit/:id', component: DeviceFormComponent},
  { path: 'devicetypes', component: DeviceTypesComponent},
  { path: 'devicetypes/new', component: DeviceTypeFormComponent},
  { path: 'devicetypes/edit/:id', component: DeviceTypeFormComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
