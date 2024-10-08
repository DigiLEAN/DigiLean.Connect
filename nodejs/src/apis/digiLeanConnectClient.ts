import { HttpClient } from "@lib/services/httpClient.js"
import { Version1 } from "./version1.js"

export class DigiLeanConnectClient {

    constructor(clientId: string, clientSecret: string, testmode?: boolean) {
        const urls = getUrls(testmode)
        const httpClient = new HttpClient(urls.apiBaseUrl, urls.authUrl, clientId, clientSecret)
        this.v1 = new Version1(httpClient)
    }

    public v1: Version1
}

function getUrls(testmode?: boolean) {
    if (testmode) {
        return {
            authUrl: "https://auth-test.digilean.tools",
            apiBaseUrl: "https://apidev.digilean.tools",
        }
    }
    return {
        authUrl: "https://auth.digilean.tools",
        apiBaseUrl: "https://connect.digilean.tools",
    }
}