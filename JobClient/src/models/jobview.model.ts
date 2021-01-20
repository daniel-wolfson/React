// job view model
// example: { "id": "00001111222233334444555577770001", "viewDate": "2019-05-04T12:00:00.000Z", "viewCountPredicted": 100, "viewCount": 100 },
export class JobView {
    id : string;
    viewDate : string;
    viewsPredicted : number;
    views: number;
    activeJobs: number;

    constructor({ id, viewDate, viewNumPredicted, viewNum, activeJobs }: { id: string; viewDate: Date; viewNumPredicted: number; viewNum: number; activeJobs: number}) {
        this.id = id; //"00001111222233334444555577770001" guid
        this.viewDate = viewDate.toLocaleDateString(); //"2019-05-04T12:00:00.000Z", 
        this.viewsPredicted = viewNumPredicted;
        this.views = viewNum;
        this.activeJobs = activeJobs;
    }
}