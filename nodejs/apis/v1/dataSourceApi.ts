import { ApiEndpointBase } from "apis/apiEndpointBase";

export class DataSourceApiV1 extends ApiEndpointBase {
    constructor() {
        super("/v1/datasources")
    }

    async get() {
        
    }
}