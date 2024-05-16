/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CustomFieldValue } from './CustomFieldValue.js';
import type { IncidentCategory } from './IncidentCategory.js';
import type { IncidentCause } from './IncidentCause.js';
import type { IncidentConsequence } from './IncidentConsequence.js';
import type { IncidentSeverity } from './IncidentSeverity.js';

export type IncidentCreate = {
    id?: number;
    incidentTypeId: number;
    title: string;
    incidentDate: string;
    text?: string | null;
    reportedByGroupId?: number | null;
    followUpGroupId?: number | null;
    projectId?: number | null;
    areaId?: number | null;
    dueDate?: string | null;
    statusModifiedDate?: string | null;
    severity: number;
    severityText?: IncidentSeverity;
    status?: number;
    evaluationStatus?: number | null;
    evaluationText?: string | null;
    responsibleUserId?: string | null;
    responsible?: string | null;
    responsibleDisplayName?: string | null;
    createdDate?: string;
    createdByUserId?: string | null;
    createdByUser?: string | null;
    createdByUserDisplayName?: string | null;
    statusNewDate?: string | null;
    externalId?: string | null;
    isAnonymous?: boolean;
    consequences?: Array<IncidentConsequence> | null;
    categories?: Array<IncidentCategory> | null;
    causes?: Array<IncidentCause> | null;
    customFields?: Array<CustomFieldValue> | null;
};
