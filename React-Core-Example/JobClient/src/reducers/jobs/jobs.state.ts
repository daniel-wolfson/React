import { SET_JOBS_DATA } from '../../constants/action-types';
import { Job } from '../../models/job.model';

const initialState = new Array<Job>();

// eslint-disable-next-line import/no-anonymous-default-export
export default (state = initialState, action: any) => {
  switch (action.type) {
    case SET_JOBS_DATA:
      return action.payload || initialState;
    default:
      return state;
  }
};