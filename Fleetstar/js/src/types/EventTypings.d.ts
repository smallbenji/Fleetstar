export interface Arrangement {
    id: string;
    name: string;
    image: string;
    description: string;
    fromDate: Date;
    toDate: Date;
    forWho: string;
    extrafields: any[];
}