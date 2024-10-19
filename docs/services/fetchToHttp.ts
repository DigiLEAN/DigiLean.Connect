interface HeaderParams {
    isEncode: boolean
    params: string
}

function removeLastBackslash(str: string): string {
    return str.replace(/ \\$/, '')
}
  
  
export const isInstanceOfHeaders = (val: any): boolean => {
    if (typeof Headers !== 'function') {
      /**
       * Environment does not support the Headers constructor
       * old internet explorer?
       */
      return false
    }
    return val instanceof Headers
}
  
const getHeaderString = (name: string, val: any): string => `${name}: ${`${val}`.replace(/(\\|")/g, '\\$1')}`
  
export const generateHeadersArgument = (headers?: any): HeaderParams => {
    if (!headers || Object.keys(headers).length === 0) {
      return {
        params: '',
        isEncode: false,
      }
    }
  
    let isEncode = false
    let headerParam = ''
    if (isInstanceOfHeaders(headers)) {
      headers.forEach((val: any, name: string) => {
        if (name.toLocaleLowerCase() !== 'content-length') {
          headerParam += `${getHeaderString(name, val)} \\\n`
        }
        if (name.toLocaleLowerCase() === 'accept-encoding') {
          isEncode = true
        }
      })
    } else if (headers) {
      Object.keys(headers).forEach((name) => {
        if (name.toLocaleLowerCase() !== 'content-length') {
          headerParam += `${getHeaderString(name, headers[name])} \\\n`
        }
        if (name.toLocaleLowerCase() === 'accept-encoding') {
          isEncode = true
        }
      })
    }
  
    headerParam = headerParam.trim()
  
    headerParam = removeLastBackslash(headerParam)
  
    headerParam = `${headerParam}`
  
    return {
      params: headerParam,
      isEncode,
    }
}
  
export function escapeBody(body: any): string {
    if (typeof body !== 'string') {
      return body
    }
    return body.replace(/'/g, `'\\''`)
}
  
export function generateBody(body: any): string {
    if (!body) {
      return ''
    }
  
    if (typeof body === 'object') {
      return ` --data '${escapeBody(JSON.stringify(body))}'`
    }
  
    return ` --data '${escapeBody(body)}'`
}
  
export function generateCompress(isEncode: boolean): string {
    return isEncode ? ' --compressed' : ''
}
  
export const fetchToHttp = ({
    url,
    method,
    headers,
    body,
  }: { url: string, method: string, headers: any, body: any }): string => {
    const headersArgument = generateHeadersArgument(headers)
  
    let output = `${method} ${url}`
  
    if (headersArgument.params) {
      output += ` \n${headersArgument.params}`
    }
  
    if (body) {
      output += ` \\\n${generateBody(body)}`
    }
  
    if (headersArgument.isEncode) {
      output += ` \\\n${generateCompress(headersArgument.isEncode)}`
    }
  
    return output.trim()
}
  
export default fetchToHttp
  