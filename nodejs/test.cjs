const https = require("https")

const tokenEndpoint = "https://authdev.digilean.tools/connect/token"
const clientId = "5dbcb85b-ce4f-42d4-825d-28ffc5c136d7"

const clientSecret = "xxx"
//console.log("clientSecret", clientSecret)

function post(url, data, contentType) {
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

function handleResponse(res, resolve, reject) {
    let {statusCode} = res
    let error = null

    if (!statusCode) statusCode = 500
    if (statusCode >= 400) {
        error = new Error(`Request Failed.\nStatus Code: ${statusCode}`);
        res.resume()
    }

    res.setEncoding("utf8")
    let rawData = ""
    res.on("data", (chunk) => {
        rawData += chunk
    })
    res.on("end", () => {
        const errmsg = `Status: ${statusCode} - msg: ${rawData}`
        if (error)
            reject(errmsg)
        else
            resolve(rawData)
    })
}

async function perform() {
    const xFormBody = `client_id=${encodeURI(clientId)}&client_secret=${encodeURI(clientSecret)}&grant_type=client_credentials`

    console.log("xFormBody", xFormBody)

    const tokenRaw = await post(tokenEndpoint, xFormBody, "application/x-www-form-urlencoded")
    const tokenRes = JSON.parse(tokenRaw)

    return tokenRes.access_token
}

perform().then((token) => {
    console.log("set access token", token)
}).catch(err => {
    console.error(err)
}).finally(() => {
    console.log("done")
})