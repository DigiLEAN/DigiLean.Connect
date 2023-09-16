import { DigiLeanConnectClient } from "@lib/index"
import config from "./config"
async function test() {
    const client = new DigiLeanConnectClient(config.clientId, config.clientSecret, true)
    // const sources = await client.v1.dataSources.getAll()
    // console.log(sources)
    // console.log("many sources, not one source")
    const source = await client.v1.dataSources.get(432)
    console.log(source)
    const values = await client.v1.dataValues.getAllByDatasourceId(432)
    console.log(values)
}

test().then(() => console.log("done")).catch(err => console.error(err))