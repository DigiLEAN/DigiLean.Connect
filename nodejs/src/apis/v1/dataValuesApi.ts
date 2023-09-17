import { ApiEndpointBase } from "@lib/apis/apiEndpointBase.js"
import { HttpClient } from "@lib/services/httpClient.js"
import { DataValuesPaged } from "@lib/types/index.js"

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