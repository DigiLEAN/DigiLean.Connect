/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Category } from './Category.js';
import type { Cause } from './Cause.js';
import type { CustomField } from './CustomField.js';
import type { IncidentTypeConsequence } from './IncidentTypeConsequence.js';

export type IncidentTypeConfiguration = {
    id?: number;
    title?: string | null;
    description?: string | null;
    customFields?: Array<CustomField> | null;
    categories?: Array<Category> | null;
    consequences?: Array<IncidentTypeConsequence> | null;
    causes?: Array<Cause> | null;
};
