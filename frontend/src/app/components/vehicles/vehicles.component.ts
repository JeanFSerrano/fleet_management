import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { Vehicle } from 'src/app/interfaces/Vehicle';
import { VehicleService } from 'src/app/services/vehicle.services';


@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.css']
})
export class VehiclesComponent {
  title = 'fleet_management'

  @ViewChild('details') details!: ElementRef

  reverse: boolean = true

  vehicles$ = new Observable<Vehicle[]>()

  id = ''
  type = ''
  seats = ''
  brand = ''
  model = ''
  year = ''
  kmDriven = ''
  runningDoors = ''
  normalDoors = ''
  fleetId = ''

  constructor(private vehicleService: VehicleService) {
    this.getAllVehicles()

  }

  convertStringToInt(value: string): number {
    const parsedValue = parseInt(value);
    return isNaN(parsedValue) ? 0 : parsedValue;
  }


  getAllVehicles() {
    this.vehicles$ = this.vehicleService.getVehicles()
  }

  createVehicle() {

    return this.vehicleService.createVehicle({

      type: this.type,
      seats: parseInt(this.seats),
      brand: this.brand,
      model: this.model,
      year: parseInt(this.year),
      kmDriven: parseInt(this.kmDriven),
      runningDoors: parseInt(this.runningDoors),
      normalDoors: parseInt(this.normalDoors),

    }).subscribe(_ => this.getAllVehicles())

  }

  fillFields(vehicle: Vehicle) {

    this.details.nativeElement.open = !this.details.nativeElement.open

    this.id = vehicle.id
    this.type = vehicle.type
    this.seats = vehicle.seats.toString()
    this.brand = vehicle.brand
    this.model = vehicle.model
    this.year = vehicle.year.toString()
    this.kmDriven = vehicle.kmDriven.toString()
    this.runningDoors = vehicle.runningDoors.toString()
    this.normalDoors = vehicle.normalDoors.toString()
    this.fleetId = vehicle.fleetId
  }

  update() {

    this.details.nativeElement.open = !this.details.nativeElement.open

    return this.vehicleService.updateVehicle({

      id: this.id,
      type: this.type,
      seats: parseInt(this.seats),
      brand: this.brand,
      model: this.model,
      year: parseInt(this.year),
      kmDriven: parseInt(this.kmDriven),
      runningDoors: parseInt(this.runningDoors),
      normalDoors: parseInt(this.normalDoors),
      fleetId: this.fleetId

    }).subscribe(_ => this.getAllVehicles())

  }

  onSubmit(vehicleForm: NgForm) {
    vehicleForm.reset()
  }

  delete(id: string) {

    return this.vehicleService.deleteVehicle(id).subscribe(_ => this.getAllVehicles())
  }

  sortColumn(column: string | number) {

    this.vehicleService.getVehicles().subscribe((vehicles: any[]) => {

      if (typeof column === 'string') {

        const compareFunction = this.reverse
          ? (a: any, b: any) => a[column].localeCompare(b[column])
          : (a: any, b: any) => b[column].localeCompare(a[column])

        vehicles.sort(compareFunction)
        this.reverse = !this.reverse
      }

      else if (typeof column === 'number') {

        const compareFunction = this.reverse
          ? (a: any, b: any) => a.column - b.column
          : (a: any, b: any) => b.column - a.column

        vehicles.sort(compareFunction)
        this.reverse = !this.reverse
      }

      this.vehicles$ = of(vehicles)
    })
  }
}
