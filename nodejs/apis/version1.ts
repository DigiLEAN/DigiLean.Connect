import { HttpClient } from "../services/httpClient"
import { DataSourceApiV1 } from "./v1/dataSourceApi"
import { DataValuesApiV1 } from "./v1/dataValuesApi"

export class Version1 {
    
    constructor(client: HttpClient) {
        this.dataSources = new DataSourceApiV1(client)
        this.dataValues = new DataValuesApiV1(client)
    }

    public dataSources: DataSourceApiV1
    public dataValues: DataValuesApiV1
}