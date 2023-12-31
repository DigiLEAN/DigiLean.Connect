import * as https from "https"
import { IncomingMessage } from "http"
import { ProblemDetails } from "@lib/types/errors.js"

export function get(url: string): Promise<string> {
    return new Promise((resolve, reject) => {
        const request = https.request(url, (res) => {
            handleResponse(res, resolve, reject)
        })
            .on("error", (e) => reject(e))
        request.end()
    })
}

export function post(url: string, data?: any, contentType?: string): Promise<string> {
    return new Promise((resolve, reject) => {
        let postData = ""
        if (data && typeof data === "object")
            postData = JSON.stringify(data)
        else if (data && typeof data === "string")
            postData = data
        
        const options = {
            method: "POST",
            headers: {
                "Content-Type": contentType ?? "application/json",
                "Content-Length": Buffer.byteLength(postData)
            }
        }
        const request = https.request(url, options, (res) => {
            handleResponse(res, resolve, reject)
        })
            .on("error", (e) => reject(e))
        if (postData)
            request.write(postData)
        request.end()
    })
}

export function handleResponse(res: IncomingMessage, resolve: (data:any)=>void, reject:(msg:string | ProblemDetails)=>void) {
    let {statusCode} = res
    let error: Error | null = null

    if (!statusCode) statusCode = 500
    if (statusCode >= 400) {
        error = new Error(`Request Failed.\nStatus Code: ${statusCode}`);
        res.resume()
    }

    res.setEncoding("utf8")
    let rawData = ""
    res.on("data", (chunk: string) => {
        rawData += chunk
    })
    res.on("end", () => {
        const errmsg = `Status: ${statusCode} - msg: ${rawData}`
        if (error) {
            const pd = tryParseProblemDetails(rawData)
            if (pd)
                reject(pd)
            reject(errmsg)
        } else {
            resolve(rawData)
        }
    })
}

function tryParseProblemDetails(rawData: string): any {
    try {
        return JSON.parse(rawData) as ProblemDetails
    } catch (e) {
        return ""
    }
}