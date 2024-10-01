/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { CustomFieldValue } from './CustomFieldValue.js';
import type { IncidentCategory } from './IncidentCategory.js';
import type { IncidentCause } from './IncidentCause.js';
import type { IncidentConsequence } from './IncidentConsequence.js';
import type { IncidentSeverity } from './IncidentSeverity.js';
import type { IncidentStatus } from './IncidentStatus.js';

export type IncidentCreate = {
    statusModifiedDate?: string | null;
    severityText?: IncidentSeverity;
    responsible?: string | null;
    responsibleDisplayName?: string | null;
    createdDate?: string;
    createdByUserId?: string | null;
    createdByUser?: string | null;
    createdByUserDisplayName?: string | null;
    statusNewDate?: string | null;
    consequences?: Array<IncidentConsequence> | null;
    categories?: Array<IncidentCategory> | null;
    causes?: Array<IncidentCause> | null;
    customFields?: Array<CustomFieldValue> | null;
    status?: number;
    statusText?: IncidentStatus;
    incidentTypeId: number;
    severity: number;
    reportedByGroupId?: number | null;
    followUpGroupId?: number | null;
    responsibleUserId?: string | null;
    title: string;
    text?: string | null;
    incidentDate: string;
    resolvedDate?: string | null;
    dueDate?: string | null;
    evaluationStatus?: number | null;
    evaluationText?: string | null;
    isAnonymous?: boolean;
    areaId?: number | null;
    projectId?: number | null;
    externalId?: string | null;
};
