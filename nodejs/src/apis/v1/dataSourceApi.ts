import { ApiEndpointBase } from "@lib/apis/apiEndpointBase"
import { HttpClient } from "@lib/services/httpClient"
import { DataSource, DataSourceInfo } from "@lib/types"

export class DataSourceApiV1 extends ApiEndpointBase {
    constructor(client: HttpClient) {
        super(client, "/v1/datasources")
    }

    async getAll() {
        const resRaw = await this.client.get(this.basePath)
        const res = JSON.parse(resRaw) as DataSourceInfo[]
        return res
    }
    async get(id: number) {
        const url = `${this.basePath}/${id}`
        const resRaw = await this.client.get(url)
        const res = JSON.parse(resRaw) as DataSource
        return res
    }
}