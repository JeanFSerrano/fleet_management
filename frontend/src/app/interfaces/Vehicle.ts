export type Vehicle = {
    
    id: string
    type : string
    seats : number 
    brand : string
    model : string
    year : number
    kmDriven : number
    runningDoors : number
    normalDoors : number
    fleetId : string
}

export type VehicleWithNoId = Omit<Vehicle, 'id' | 'fleetId'>
