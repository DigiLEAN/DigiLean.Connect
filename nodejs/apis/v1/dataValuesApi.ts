import { ApiEndpointBase } from "../apiEndpointBase"
import { HttpClient } from "../../services/httpClient"
import { DataValuesPaged } from "types"

export class DataValuesApiV1 extends ApiEndpointBase {
    constructor(client: HttpClient) {
        super(client, "/v1/datasources")
    }

    async getAllByDatasourceId(datasourceId: number) {
        const url = `${this.basePath}/${datasourceId}/values`
        const resRaw = await this.client.get(url)
        const res = JSON.parse(resRaw) as DataValuesPaged
        return res
    }
}