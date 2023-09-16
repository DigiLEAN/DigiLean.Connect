import { HttpClient } from "src/services/httpClient"

export class ApiEndpointBase {
    protected basePath = ""
    protected client: HttpClient
    constructor(client: HttpClient, basePath: string) {
        this.client = client
        this.basePath = basePath
    }
}