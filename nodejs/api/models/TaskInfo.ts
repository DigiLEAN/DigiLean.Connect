/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { TaskStatus } from './TaskStatus';

export type TaskInfo = {
    id?: number;
    parentId?: number | null;
    lastModified?: string | null;
    responsibleUser?: string | null;
    externalId?: string | null;
    boardId?: number | null;
    title: string;
    description?: string | null;
    status?: TaskStatus;
    responsibleUserId?: string | null;
    dueDate?: string | null;
    startDate?: string | null;
    rowCategoryId?: number | null;
    columnCategoryId?: number | null;
    tags?: Array<string> | null;
};
