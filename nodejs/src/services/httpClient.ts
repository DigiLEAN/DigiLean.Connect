import https from "https"
import { handleResponse } from "./httpService.js"
import { getClientToken } from "./authentication.js"

export class HttpClient  {
    private authUrl = ""
    private apiBaseUrl = ""
    private host = ""
    private clientId = ""
    private clientSecret = ""
    private token = ""

    constructor(apiBaseUrl: string, authUrl: string, clientId: string, clientSecret: string) {
        this.apiBaseUrl = apiBaseUrl
        this.host = apiBaseUrl.replace("https://", "")
        this.authUrl = authUrl
        this.clientId = clientId
        this.clientSecret = clientSecret
    }
    async get(path: string) {
        const options = await this.createRequestOptions("GET", path)
        return this.request(options)
    }
    async delete(path: string) {
        const options = await this.createRequestOptions("DELETE", path)
        return this.request(options)
    }
    async post(path: string, data: any) {
        const options = await this.createRequestOptions("POST", path)
        return this.request(options, data)
    }
    async createRequestOptions(method: string, path: string) {
        const token = await this.getToken()
        const options: https.RequestOptions = {
            method,
            host: this.host,
            path,
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token,
            }
        }
        return options
    }
    request(options: https.RequestOptions, data?: any): Promise<string> {
        let postData = ""
        if (data && typeof data === "object")
            postData = JSON.stringify(data)
        else if (data && typeof data === "string")
            postData = data

        if (postData)
            options.headers!["Content-Length"] = Buffer.byteLength(postData)

        return new Promise((resolve, reject) => {
            const request = https.request(options, (res) => {
                handleResponse(res, resolve, reject)
            })
                .on("error", (e) => reject(e))
            if (postData)
                request.write(postData)
            request.end()
        })
    }
    
    async getToken() {
        if (this.token)
            return this.token
        const auth = await getClientToken(this.authUrl, this.clientId, this.clientSecret)
        this.token = auth.access_token
        return auth.access_token
    }
}