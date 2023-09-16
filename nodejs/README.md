# DigiLEAN Connect

NodeJs package for interacting with out API [DigiLEAN Connect](https://connect.digilean.tools/swagger/index.html)

## Usage
```js
import { DigiLeanConnectClient } from "@digilean/connect"

const client = new DigiLeanConnectClient("clientId", "secret")
async function test() {
    const values = await client.v1.dataValues.getAllByDatasourceId(432)
    console.log(values)
}

test().catch(err => console.error(err))
```