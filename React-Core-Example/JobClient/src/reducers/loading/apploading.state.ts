import { APP_LOADING } from '../../constants/action-types';

const initialState = false;

// eslint-disable-next-line import/no-anonymous-default-export
export default (state = initialState, action: any) => {
  switch (action.type) {
    case APP_LOADING:
      return action.payload || initialState;
    default:
      return state;
  }
};