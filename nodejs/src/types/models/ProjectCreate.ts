/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

export type ProjectCreate = {
    projectNumber: string;
    name: string;
    status?: string | null;
    description?: string | null;
    startDate?: string | null;
    endDate?: string | null;
    estimatedStartDate?: string | null;
    estimatedEndDate?: string | null;
    customerNumber?: string | null;
    ownerEmail?: string | null;
    membersEmail?: Array<string> | null;
    externalId?: string | null;
};
