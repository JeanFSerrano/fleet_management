import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Fleet } from 'src/app/interfaces/Fleet';
import { FleetService } from 'src/app/services/fleet.service';

@Component({
  selector: 'app-fleets',
  templateUrl: './fleets.component.html',
  styleUrls: ['./fleets.component.css']
})
export class FleetsComponent {
  title = 'fleet_management';

  fleets$ = new Observable<Fleet[]>()

  id = ''
  name = ''
  cnpj = ''


  constructor(private fleetService: FleetService) {
    this.gettAllFleets()
  }

  gettAllFleets() {

    this.fleets$ = this.fleetService.getFleets()

  }

  createFleet() {

    if (!this.name || !this.cnpj) {
      return
    }

    return this.fleetService.createFleet({ name: this.name, cnpj: this.cnpj })
      .subscribe(() => this.gettAllFleets())
  }

  update() {
    this.fleetService.updateFleet({ id: this.id, name: this.name, cnpj: this.cnpj })
      .subscribe(_ => this.gettAllFleets())
  }


  fillFields(fleet: Fleet) {
    this.id = fleet.id
    this.cnpj = fleet.cnpj
    this.name = fleet.name

  }

  remove(id: string) {
    return this.fleetService.remove(id).subscribe(_ => this.gettAllFleets())
  }
}

