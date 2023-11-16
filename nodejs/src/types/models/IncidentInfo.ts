/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { IncidentCategory } from './IncidentCategory.js';
import type { IncidentCause } from './IncidentCause.js';
import type { IncidentConsequence } from './IncidentConsequence.js';
import type { IncidentCustomField } from './IncidentCustomField.js';
import type { IncidentSeverity } from './IncidentSeverity.js';
import type { IncidentStatus } from './IncidentStatus.js';

export type IncidentInfo = {
    id?: number;
    status?: number;
    statusText?: IncidentStatus;
    deviationTypeId?: number;
    deviationType?: string | null;
    severity?: number;
    severityText?: IncidentSeverity;
    reportedByGroupId?: number | null;
    reportedByGroup?: string | null;
    followUpGroupId?: number | null;
    followUpGroup?: string | null;
    text?: string | null;
    title?: string | null;
    lastModified?: string;
    reportedByUserId?: string | null;
    reportedBy?: string | null;
    incidentDate?: string;
    resolvedDate?: string | null;
    dueDate?: string | null;
    responsibleUserId?: string | null;
    responsible?: string | null;
    projectId?: number | null;
    project?: string | null;
    consequences?: Array<IncidentConsequence> | null;
    categories?: Array<IncidentCategory> | null;
    reasons?: Array<IncidentCause> | null;
    customFields?: Array<IncidentCustomField> | null;
};
