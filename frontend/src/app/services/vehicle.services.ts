import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment.development";
import { Vehicle, VehicleWithNoId } from "../interfaces/Vehicle";

@Injectable({
    providedIn: 'root'
})

export class VehicleService {

    private url = `${environment.api}/vehicles`

    constructor(private httpClient: HttpClient) { }

    getVehicles() {

        return this.httpClient.get<Vehicle[]>(this.url)
    }

    createVehicle(vehicle: VehicleWithNoId) {

        return this.httpClient.post<Vehicle>(`${this.url}/new`, vehicle)
    }

    updateVehicle(vehicle: Vehicle) {

        return this.httpClient.put<Vehicle>(`${this.url}/${vehicle.id}`, vehicle)
    }

    deleteVehicle(id: string) {

        return this.httpClient.delete<void>(`${this.url}/${id}`)
    }
}