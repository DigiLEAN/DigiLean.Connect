import { ApiEndpointBase } from "../apiEndpointBase"
import { HttpClient } from "../../services/httpClient"
import { DataSourceInfo } from "../../types"

export class DataSourceApiV1 extends ApiEndpointBase {
    constructor(client: HttpClient) {
        super(client, "/v1/datasources")
    }

    async getAll() {
        const resRaw = await this.client.get(this.baseUrl)
        const res = JSON.parse(resRaw) as DataSourceInfo[]
        return res
    }
    async get(id: number) {
        const url = `${this.baseUrl}/${id}`
        const resRaw = await this.client.get(url)
        const res = JSON.parse(resRaw) as DataSourceInfo
        return res
    }
}