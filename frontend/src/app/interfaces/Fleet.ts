export type Fleet = {
    id: string
    name: string
    cnpj: string
}

export type FleetWithNoId = Omit<Fleet, 'id'>