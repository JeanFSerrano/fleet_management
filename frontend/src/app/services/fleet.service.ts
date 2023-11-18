import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment.development";
import { HttpClient } from '@angular/common/http'
import { Fleet, FleetWithNoId } from "../interfaces/Fleet";


@Injectable({
    providedIn: 'root'
})

export class FleetService {

    private url = `${environment.api}/fleets`

    constructor(private httpClient: HttpClient) {
    }

    getFleets() {

        return this.httpClient.get<Fleet[]>(this.url)
    }

    createFleet(fleet: FleetWithNoId) {

        return this.httpClient.post<Fleet>(`${this.url}/new`, fleet)
    }

    updateFleet(fleet: Fleet) {

        return this.httpClient.put<Fleet>(`${this.url}/${fleet.id}`, fleet)
    }

    remove(id: string) {
        return this.httpClient.delete<void>(`${this.url}/${id}`)
    }
}