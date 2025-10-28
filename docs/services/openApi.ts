import * as vitepressOpenApi from "vitepress-openapi"
import { oas30 } from "openapi3-ts"
import { useSidebar } from "vitepress-openapi"

import spec from "../openApi/OpenApi3.0.json" with { type: "json" }


export const getPaths = () => {
    return vitepressOpenApi.usePaths({ spec })
    .getPathsByVerbs()
    .map(v => {
        return {
            params: {
                operationId: v?.operationId,
                pageTitle: v?.summary
            }
        }
    })
}

let openapi = vitepressOpenApi.OpenApi({spec});

// function generateBruRequest(request) {
//     const { url, method, headers, body, query } = request;
  
//     const methodLower = method.toLowerCase();
  
//     const queryString = query && Object.keys(query).length
//       ? `${url}?${new URLSearchParams(query).toString()}`
//       : url;
  
//     const headersSection = headers && Object.keys(headers).length
//       ? `headers {\n${Object.entries(headers)
//           .map(([key, value]) => `  ${key}: ${value}`)
//           .join('\n')}\n}`
//       : '';
  
//     const bodySection = body
//       ? `body {\n  ${JSON.stringify(body, null, 2).replace(/\n/g, '\n  ')}\n}`
//       : '';
  
//     const bruRequest = `${methodLower} {
//         url: ${queryString}
//     }

//         ${headersSection}

//         ${bodySection}
//     `;

//     return bruRequest
//         .trim()
//         .replace(/\n{2,}/g, '\n\n') // Remove extra newlines
// }

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
    const baseUrl = openapi.getServers()
    return baseUrl[0] as string
}

export function getOperationPath(operationId: string) {
    const path = openapi.getOperationPath(operationId)
    return path as string
}

export function getOperationMethod(operationId: string) {
    const method = openapi.getOperationMethod(operationId)
    return method as string
}

