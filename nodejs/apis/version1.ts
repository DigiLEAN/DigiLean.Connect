import { HttpClient } from "../services/httpClient"
import { DataSourceApiV1 } from "./v1/dataSourceApi"

export class Version1 {
    public dataSources: DataSourceApiV1
    constructor(client: HttpClient) {
        this.dataSources = new DataSourceApiV1(client)
    }
}