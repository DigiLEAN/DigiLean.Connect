import { ApiEndpointBase } from "@lib/apis/apiEndpointBase.js"
import { HttpClient } from "@lib/services/httpClient.js"
import { DataValue, DataValuesPaged } from "@lib/types/index.js"

export class DataValuesApiV1 extends ApiEndpointBase {
    constructor(client: HttpClient) {
        super(client, "/v1/datasources")
    }

    async getAllByDatasourceId(datasourceId: number) {
        const url = `${this.basePath}/${datasourceId}/values`
        const resRaw = await this.http.get(url)
        return JSON.parse(resRaw) as DataValuesPaged
    }
    async deleteValue(dataSourceId: number, dataValueId: number) {
        const url = `${this.basePath}/${dataSourceId}/values/${dataValueId}`
        await this.http.delete(url)
        return true
    }
    async writeValue(dataSourceId: number, dataValue: DataValue) {
        if (dataSourceId == 0)
            throw new Error("DataSourceId cant be 0")
            
        const url = `${this.basePath}/${dataSourceId}/values`
        const resRaw = await this.http.post(url, dataValue)
        return JSON.parse(resRaw) as DataValue
    }
}