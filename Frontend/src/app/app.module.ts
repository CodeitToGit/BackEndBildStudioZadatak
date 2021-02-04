import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DevicesComponent } from './components/devices/devices.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DeviceFormComponent } from './components/devices/device-form/device-form.component';
import { DeviceTypesComponent } from './components/device-types/device-types.component';
import { IfNullPipe } from './helpers/ifnull.pipe';
import { DeviceTypeFormComponent } from './components/device-types/device-type-form/device-type-form.component';



@NgModule({
  declarations: [
    AppComponent,
    DevicesComponent,
    NavBarComponent,
    DeviceFormComponent,
    DeviceTypesComponent,
    IfNullPipe,
    DeviceTypeFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
