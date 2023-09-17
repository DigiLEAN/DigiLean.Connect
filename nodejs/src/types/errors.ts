/**
 * Describes a standard error response from the API according to rfc7807.
 * https://datatracker.ietf.org/doc/html/rfc7807
 */

interface AspNetErrorMessage extends Record<string, Array<string>> {

}
export interface ProblemDetails {
    status: number
    type: string
    title: string
    detail: string
    traceId: string
    errors?: AspNetErrorMessage
}

