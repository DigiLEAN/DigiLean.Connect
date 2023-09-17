import { HttpClient } from "@lib/services/httpClient.js"

export class ApiEndpointBase {
    protected basePath = ""
    protected http: HttpClient
    constructor(client: HttpClient, basePath: string) {
        this.http = client
        this.basePath = basePath
    }
}