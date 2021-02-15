// job model
// example: { "id": "00001111222233334444555577770001", "CreateDate": "2019-05-04T12:00:00.000Z", "description": "Job01", "active": true },
export class Job {
    id : string;
    createDate : string;
    description : string | undefined;
    active: boolean;

    constructor(id: string, createDate: Date, active: boolean, description: string | undefined = undefined) {
        this.id = id; // guid
        this.createDate = createDate.toLocaleDateString(); 
        this.active = active;
        this.description = description ?? "Job-" + id;
    }
}