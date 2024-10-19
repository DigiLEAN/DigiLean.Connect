import * as fs from "fs"
import * as path from "path"
import * as http from "https"

let swaggerUrl = "https://connect.digilean.tools/swagger/v1/swagger.json"
let localFolder = "openApi"
let localFile = "OpenApi3.0.json"

function saveFile(content, directory, name){
    return new Promise((resolve, reject) => {
        if (!fs.existsSync(directory)){
            fs.mkdirSync(directory)
        }
        const fullPath = path.join(directory, name)
        fs.writeFile(fullPath, content, (err) => {
            if(err)
                reject(err)
            else
                resolve(fullPath)
        })
    })
}

function getFileFromHttp(url) {
    return new Promise((resolve, reject) => {
        const request = http.request(url, (res) => {
            let data = ""
            res.on("data", (chunk) => data += chunk)
            res.on("end", () => resolve(data))
        })
            .on("error", (e) => reject(e))
        request.end()
    })
}

const getAndSave = async () => {
    try {
        const fileContent = await getFileFromHttp(swaggerUrl)
        if (!fileContent)
            console.error(`no file content for ${swaggerUrl}`)
        await saveFile(fileContent, localFolder, localFile)
    }
    catch (err) {
        console.error(err)
    }
}
getAndSave().then(() => console.log("done"))
    .catch(err => console.error(err))
