import { SET_JOBVIEWS_DATA } from '../../constants/action-types';
import { JobView } from '../../models/jobview.model';

const initialState = new Array<JobView>();

// eslint-disable-next-line import/no-anonymous-default-export
export default (state = initialState, action: any) => {
  switch (action.type) {
    case SET_JOBVIEWS_DATA:
      return action.payload || initialState;
    default:
      return state;
  }
};