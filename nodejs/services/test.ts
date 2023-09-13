import * as authService from "./authentication"


async function test() {
    const auth = await authService.authenticateClient("https://authdev.digilean.tools", "x", "y")
    console.log(auth)
}

test().then(() => console.log("done")).catch(err => console.error(err))