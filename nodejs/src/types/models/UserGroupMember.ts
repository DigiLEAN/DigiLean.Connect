/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AssetRoleType } from './AssetRoleType.js';

export type UserGroupMember = {
    userId: string;
    userName?: string | null;
    azureObjectId?: string | null;
    groupId?: number;
    groupRole: AssetRoleType;
};
