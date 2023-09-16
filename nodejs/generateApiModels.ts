import * as OpenAPI from "openapi-typescript-codegen"
import * as fs from "fs"
import * as path from "path"
import * as http from "./src/services/httpService"

const swaggerUrl = "https://apidev.digilean.tools/swagger/v1/swagger.json"
const localFolder = "src/types"
const localFile = "swagger.json"

const saveFile = (content: string, directory: string, name: string) => {
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

const generateModels = async () => {
    try {
        const fileContent = await http.get(swaggerUrl)
        if (!fileContent)
            console.error(`no file content for ${swaggerUrl}`)
        await saveFile(fileContent, localFolder, localFile)
        OpenAPI.generate({
            input: `./${localFolder}/${localFile}`,
            output: `./${localFolder}`,
            exportCore: false,
            exportServices: false,
            exportModels: true,
            exportSchemas: false
        })
    }
    catch (err) {
        console.error(err)
    }
}
generateModels().then(() => console.log("done"))
    .catch(err => console.error(err))
