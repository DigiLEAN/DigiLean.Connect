import { DiscoveryDocument, TokenResponse } from "types/authentication"
import * as httpService from "./httpService"

const disco = "/.well-known/openid-configuration"

export async function getDiscoveryDocument(authServerUrl: string): Promise<DiscoveryDocument> {
    const doc = await httpService.get(authServerUrl + disco)
    const docJson = JSON.parse(doc) as DiscoveryDocument
    return docJson
}

export async function getClientToken(authServerUrl: string, clientId: string, clientSecret: string): Promise<TokenResponse> {
    const doc = await getDiscoveryDocument(authServerUrl)
    const xFormBody = `client_id=${encodeURI(clientId)}&client_secret=${encodeURI(clientSecret)}&grant_type=client_credentials`
    console.log("xFormBody", xFormBody)
    const tokenRaw = await httpService.post(doc.token_endpoint, xFormBody, "application/x-www-form-urlencoded")
    return JSON.parse(tokenRaw) as TokenResponse
}