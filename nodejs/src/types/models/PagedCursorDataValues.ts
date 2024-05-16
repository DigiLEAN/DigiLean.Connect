/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { DataValue } from './DataValue.js';

export type PagedCursorDataValues = {
    pageCount?: number;
    cursor?: number;
    nextCursor?: number;
    readonly hasNext?: boolean;
    values?: Array<DataValue> | null;
};
