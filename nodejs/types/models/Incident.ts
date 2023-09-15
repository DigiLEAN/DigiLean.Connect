/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { IncidentCategory } from './IncidentCategory';
import type { IncidentCause } from './IncidentCause';
import type { IncidentConsequence } from './IncidentConsequence';
import type { IncidentCustomField } from './IncidentCustomField';
import type { IncidentSeverity } from './IncidentSeverity';
import type { IncidentStatus } from './IncidentStatus';

export type Incident = {
    project?: string | null;
    incidentType?: string | null;
    consequences?: Array<IncidentConsequence> | null;
    categories?: Array<IncidentCategory> | null;
    causes?: Array<IncidentCause> | null;
    customFields?: Array<IncidentCustomField> | null;
    id?: number;
    status?: number;
    statusText?: IncidentStatus;
    incidentTypeId: number;
    severity?: number;
    severityText?: IncidentSeverity;
    reportedByGroupId?: number | null;
    reportedByGroup?: string | null;
    reportedByUserId?: string | null;
    reportedBy?: string | null;
    reportedDate?: string;
    followUpGroupId?: number | null;
    followUpGroup?: string | null;
    responsibleUserId?: string | null;
    responsible?: string | null;
    responsibleDisplayName?: string | null;
    text?: string | null;
    title?: string | null;
    lastModified?: string;
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

