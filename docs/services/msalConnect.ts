import * as msal from "@azure/msal-browser"

const clientIds = {
    sharePoint: "a64364df-a84d-4b1a-8e7f-596436025e8e",
    sharePointSite: "01f47464-fcaa-41ea-84a9-26340bebfe40",
    azureAD:"c2e8d18f-762a-4b21-a03c-dba44be09447"
}

const getConfig = (clientId: string): msal.Configuration => {
    return {
        auth: {
            clientId,
            authority: "https://login.microsoftonline.com/common/",
            redirectUri: window.location.origin,
        },
        cache: {
            cacheLocation: "sessionStorage",
            storeAuthStateInCookie: false,
        },
        system: {
            loggerOptions: {
                loggerCallback: (level, message, containsPii) => {
                    if (containsPii) {
                        console.log(message)
                        return
                    }
                    switch (level) {
                        case msal.LogLevel.Error:
                            console.error(message)
                            return
                        case msal.LogLevel.Info:
                            console.info(message)
                            return
                        case msal.LogLevel.Verbose:
                            console.debug(message)
                            return
                        case msal.LogLevel.Warning:
                            console.warn(message)
                            return
                    }
                }
            }
        }
    }
}

let accountId = ""

const loginRequest = {
    scopes: []
}

// will sign in to AzureAd App and make it appear in customers Enterprise Apps
export async function signInAzureAdApp() {
    const config = getConfig(clientIds.azureAD)
    return await signInMsal(config)
}

export async function signInSharePointApp() {
    const config = getConfig(clientIds.sharePoint)
    return await signInMsal(config)
}
export async function signInSharePointSiteApp() {
    const config = getConfig(clientIds.sharePointSite)
    return await signInMsal(config)
}

async function signInMsal(config: msal.Configuration) {
    const msalInstance = new msal.PublicClientApplication(config)
    await msalInstance.initialize()
    const res = await msalInstance.loginPopup(loginRequest)
    return handleResponse(msalInstance, res)
}
// export function signOutMsal() {
//     const logoutRequest = {
//         account: myMSALObj.getAccountByHomeId(accountId)
//     }
//     myMSALObj.logoutPopup(logoutRequest).then(() => {
//         window.location.reload()
//     })
// }

function onLoggedIn(account: msal.AccountInfo) {
    accountId = account?.homeAccountId
    currentAccount = account
}

let currentAccount
function handleResponse(myMSALObj: msal.PublicClientApplication, resp: msal.AuthenticationResult) {
    if (resp !== null) {
        myMSALObj.setActiveAccount(resp.account)
        onLoggedIn(resp.account)
        return resp
    }
    else {
        const currentAccounts = myMSALObj.getAllAccounts()
        if (!currentAccounts || currentAccounts.length < 1) {
            return
        }
        else if (currentAccounts.length > 1) {
            // Add choose account code here
        }
        else if (currentAccounts.length === 1) {
            const activeAccount = currentAccounts[0]
            myMSALObj.setActiveAccount(activeAccount)
            onLoggedIn(activeAccount)
            return activeAccount
        }
    }
}
// async function getTokenPopup(request, account) {
//     return await myMSALObj.acquireTokenSilent(request).catch(async (error) => {
//         console.log("silent token acquisition fails.")
//         if (error instanceof msal.InteractionRequiredAuthError) {
//             console.log("acquiring token using popup")
//             return myMSALObj.acquireTokenPopup(request).catch(error => {
//                 console.error(error)
//             })
//         }
//         else {
//             console.error(error)
//         }
//     })
// }
