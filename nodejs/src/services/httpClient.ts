import https from "https"
import { handleResponse } from "./httpService"
import { getClientToken } from "./authentication"

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
        const token = await this.getToken()
        const options: https.RequestOptions = {
            method: "GET",
            host: this.host,
            path,
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token,
            }
        }
        return this.request(options)
    }

    request(options: https.RequestOptions, data?: any): Promise<string> {
        console.log(`host: ${options.host}, path: ${options.path}`)
        return new Promise((resolve, reject) => {
            const request = https.request(options, (res) => {
                handleResponse(res, resolve, reject)
            })
                .on("error", (e) => reject(e))
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