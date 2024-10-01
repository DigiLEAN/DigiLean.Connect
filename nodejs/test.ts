import { DigiLeanConnectClient } from "./lib/index.js"
import config from "./config.js"
//import { DataValue } from "./lib/types/index.js"
async function test() {
    const client = new DigiLeanConnectClient(config.clientId, config.clientSecret, true)

    // const newValue: DataValueCreate = {
    //     dataSourceId: 432,
    //     value: 123,
    //     valueDate: new Date().toISOString()
    // }
    // const res = await client.v1.dataValues.writeValue(432, newValue)
    // console.log("newvalue", res)

    //await client.v1.dataValues.deleteValue(432, 4694270)
    const values = await client.v1.dataValues.getAllByDatasourceId(432)
    console.log(values)

    //await client.v1.dataValues.deleteValue(432, 4754300)
}

test().then(() => console.log("done")).catch(err => console.error(err))