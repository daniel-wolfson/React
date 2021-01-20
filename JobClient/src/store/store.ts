import { createStore, applyMiddleware } from 'redux';
import { composeWithDevTools } from 'redux-devtools-extension';
import logger from 'redux-logger';
import thunk from 'redux-thunk';
import appReducer from '../reducers/app';
import { appLoading } from '../reducers/loading/actions';

// middleware
import jobdata from '../middleware/jobdata.middleware';

// persisted state
const persistedState = 
localStorage.getItem('reduxState') 
  ? JSON.parse(localStorage.getItem('reduxState') || '{}') 
  : {};

// create store
const store = createStore(
  appReducer,
  persistedState,
  composeWithDevTools(
    applyMiddleware(logger, thunk, jobdata)
  ),
);

// save state to localStorage on any change
store.subscribe(() => {
  localStorage.setItem('reduxState', JSON.stringify(store.getState()));
});

// dispatch call action "appLoading"
store.dispatch(appLoading(true));

export default store;
