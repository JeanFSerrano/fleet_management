import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http'
import { ControlContainer, FormsModule, NgModelGroup } from '@angular/forms';
import { FleetsComponent } from './components/fleets/fleets.component';
import { VehiclesComponent } from './components/vehicles/vehicles.component';
import { HomeComponent } from './components/home/home.component';
import { TextInputComponent } from './components/text-input/text-input.component';


@NgModule({
  declarations: [
    AppComponent,
    FleetsComponent,
    VehiclesComponent,
    HomeComponent,
    TextInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
