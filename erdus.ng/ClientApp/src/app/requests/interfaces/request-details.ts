import { UserRequestPermissions } from './user-request-permissions';

export interface RequestDetails {
    id: number;
    photo: string;
    requester: string;
    responsiblePersonName: string;
    responsiblePersonGuid: string;
    topic: string;
    location: string;
    address: string;
    creationDate: Date;
    content: string;
    statusName: string;
    statusId: number;
    longitude: number;
    latitude: number;
    userPermissions: UserRequestPermissions;
    categoryName: string;
    categoryId: number;
    answer: string;
}

