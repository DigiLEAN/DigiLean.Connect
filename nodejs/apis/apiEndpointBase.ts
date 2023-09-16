import { HttpClient } from "services/httpClient"

export class ApiEndpointBase {
    protected baseUrl = ""
    protected client: HttpClient
    constructor(client: HttpClient, baseUrl: string) {
        this.client = client
        this.baseUrl = baseUrl
    }
}