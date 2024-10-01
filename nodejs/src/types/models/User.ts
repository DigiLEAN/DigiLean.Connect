/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

export type User = {
    id?: string | null;
    roles?: Array<string> | null;
    userName: string;
    email: string;
    useAD?: boolean;
    azureAdObjectId?: string | null;
    firstName: string;
    lastName: string;
    readonly fullName?: string | null;
    screenName?: string | null;
    isInfoScreenUser?: boolean;
    isMobileUser?: boolean;
    preferredLanguage?: string | null;
    businessUnitId?: number | null;
};
