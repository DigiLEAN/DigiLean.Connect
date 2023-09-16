import { HttpClient } from "services/httpClient";

export class DigiLeanConnectClient {

    constructor(clientId: string, clientSecret: string, testmode?: boolean) {
        const urls = getUrls(testmode)
        const httpClient = new HttpClient(urls.apiBaseUrl, urls.authUrl, clientId, clientSecret)
        
    }
}

function getUrls(testmode?: boolean) {
    if (testmode) {
        return {
            authUrl: "https://authdev.digilean.no",
            apiBaseUrl: "https://apidev.digilean.no",
        }
    }
    return {
        authUrl: "https://auth.digilean.no",
        apiBaseUrl: "https://connect.digilean.no",
    }
}