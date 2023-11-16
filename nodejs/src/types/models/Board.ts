/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { BoardCategory } from './BoardCategory.js';

export type Board = {
    rows?: Array<BoardCategory> | null;
    columns?: Array<BoardCategory> | null;
    id?: number;
    name?: string | null;
    description?: string | null;
    boardType?: string | null;
    isPublic?: boolean;
    groupId?: number | null;
    groupName?: string | null;
};
