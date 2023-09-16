import dotenv from "dotenv"
import path from "path"

const environment = process.env.NODE_ENV ?? ""
console.log("env", environment)

const envFile = environment ? `.env.${environment}` : ".env"
const envFilePath = path.join(process.cwd(), envFile)

dotenv.config({ path: envFilePath}) // const config = 

const clientId = process.env.CLIENT_ID as string
const clientSecret = process.env.CLIENT_SECRET as string

export default {
    clientId, clientSecret
}

