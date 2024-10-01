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

export type Incident = {
    id?: number;
    project?: string | null;
    incidentType?: string | null;
    severityText?: IncidentSeverity;
    reportedByGroup?: string | null;
    reportedByUserId?: string | null;
    reportedBy?: string | null;
    reportedDate?: string;
    followUpGroup?: string | null;
    responsible?: string | null;
    responsibleDisplayName?: string | null;
    lastModified?: string;
    numberOfComments?: number;
    numberOfActions?: number;
    numberOfAttachments?: number;
    consequences?: Array<IncidentConsequence> | null;
    categories?: Array<IncidentCategory> | null;
    causes?: Array<IncidentCause> | null;
    customFields?: Array<IncidentCustomField> | null;
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
