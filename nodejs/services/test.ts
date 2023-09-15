import * as authService from "./authentication"
import config from "./config"

async function test() {
    const auth = await authService.authenticateClient("https://authdev.digilean.tools", config.clientId, config.clientSecret)
    console.log(auth)
}

test().then(() => console.log("done")).catch(err => console.error(err))