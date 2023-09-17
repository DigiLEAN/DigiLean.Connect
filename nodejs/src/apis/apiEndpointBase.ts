import { HttpClient } from "@lib/services/httpClient.js"

export class ApiEndpointBase {
    protected basePath = ""
    protected client: HttpClient
    constructor(client: HttpClient, basePath: string) {
        this.client = client
        this.basePath = basePath
    }
}