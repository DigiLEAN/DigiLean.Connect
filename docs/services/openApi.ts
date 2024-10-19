import { useOpenapi, httpVerbs } from "vitepress-openapi"
import { oas30 } from "openapi3-ts"
import { useSidebar } from "vitepress-openapi"

import spec from "../openApi/OpenApi3.0.json" assert { type: "json" }

let openapi = useOpenapi({ spec })

export function getOpenApi() {
    return openapi
}

export const sidebar = useSidebar({ 
  spec,
  // Optionally, you can specify a link prefix for all generated sidebar items.
  linkPrefix: '/docs/operations/',
})

export function getOperation(operationId:string) {
    //const openApiSpec = openapi.getParsedSpec()
    const op = openapi.getOperation(operationId)
    return op as oas30.OperationObject
}

export function getBaseUrl() {
    const baseUrl = openapi.getBaseUrl()
    return baseUrl as string
}

export function getOperationPath(operationId: string) {
    const path = openapi.getOperationPath(operationId)
    return path as string
}

export function getOperationMethod(operationId: string) {
    const method = openapi.getOperationMethod(operationId)
    return method as string
}

export function paths() {
    
    // console.log("openapi", openapi.json.paths)
    if (!openapi?.json?.paths) {
        return []
    }

    const paths =  Object.keys(openapi.json.paths)
        .flatMap((path) => {
            return httpVerbs
                .filter((verb) => openapi.json.paths[path][verb])
                .map((verb) => {
                    const { operationId, summary } = openapi.json.paths[path][verb]
                    return {
                        params: {
                            operationId,
                            pageTitle: `${summary} - vitepress-openapi`,
                        },
                    }
                })
        })
    // console.log(paths)
    return paths
}
