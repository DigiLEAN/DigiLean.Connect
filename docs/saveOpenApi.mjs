import * as fs from "fs"
import * as fsp from "fs/promises"
import * as path from "path"
import * as http from "https"

const localFolder = "openApi"

function saveFile(content, directory, name){
    if (!fs.existsSync(directory)){
        fs.mkdirSync(directory)
    }
    const fullPath = path.join(directory, name)
    return fsp.writeFile(fullPath, content)
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

const getFromUrlAndSaveAs = async (url, fileName) => {
    try {
        const fileContent = await getFileFromHttp(url)
        if (!fileContent)
            throw new Error(`no file content for ${url}`)
        saveFile(fileContent, localFolder, fileName)
    }
    catch (err) {
        console.error(err)
    }
}

Promise.all([
    getFromUrlAndSaveAs("https://api-test.digilean.tools/swagger/v1/swagger.json", "OpenApi3.0.v1.json"),
    getFromUrlAndSaveAs("https://api-test.digilean.tools/swagger/v2/swagger.json", "OpenApi3.0.v2.json"),
]).then(() => console.log("done"))
    .catch(err => console.error(err))
