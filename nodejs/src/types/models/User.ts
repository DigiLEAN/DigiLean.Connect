/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

export type User = {
    id?: string | null;
    userName: string;
    email: string;
    useAD?: boolean;
    azureAdObjectId?: string | null;
    firstName: string;
    lastName: string;
    readonly fullName?: string | null;
    screenName?: string | null;
    isAdmin?: boolean;
    isBoardDesigner?: boolean;
    isA3Admin?: boolean;
    isDeviationAdmin?: boolean;
    isImprovementAdmin?: boolean;
    isProjectAdmin?: boolean;
    isStrategyAdmin?: boolean;
    isLearningAdmin?: boolean;
    isDataAdmin?: boolean;
    isMessageWriter?: boolean;
    isInfoScreenUser?: boolean;
    isMobileUser?: boolean;
    preferredLanguage?: string | null;
    businessUnitId?: number | null;
};
