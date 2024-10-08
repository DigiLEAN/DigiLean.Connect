/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { IncidentSeverity } from './IncidentSeverity.js';
import type { IncidentStatus } from './IncidentStatus.js';

export type IncidentInfo = {
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
