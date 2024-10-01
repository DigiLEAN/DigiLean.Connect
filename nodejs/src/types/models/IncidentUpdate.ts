/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { IncidentStatus } from './IncidentStatus.js';

export type IncidentUpdate = {
    id?: number;
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
