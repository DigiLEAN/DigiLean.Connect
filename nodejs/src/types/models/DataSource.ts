/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { DataSourceElement } from './DataSourceElement.js';

export type DataSource = {
    id: number;
    title?: string | null;
    description?: string | null;
    objectSource?: string | null;
    unitOfTime?: string | null;
    primaryInputSource?: string | null;
    elements?: Array<DataSourceElement> | null;
};
