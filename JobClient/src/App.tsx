import React from "react";
import "./app.css";
import { JobViewChart } from "./components/JobViewChart";
import { Layout } from "./components/Layout";

import { IState } from "./store/ISate";
import { connect } from "react-redux";

function App(props: any) {
  return (
    <div className="App">
      <link
        rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css"
      />
      <Layout>
        <JobViewChart props={props.appLoading} jobs={props.jobs} jobViews={props.jobViews} />
      </Layout>
    </div>
  );
}

const mapStateToProps = (state: IState) => {
  var {appLoading, jobs, jobViews} = state;
  return {
    appLoading,
    ...jobs,
    ...jobViews //Object.assign([], ...state.jobViews)
  }
};

// const mapDispatchToProps = (dispatch: any) => {
//   return {
//     getJobs: () => dispatch({ type: actionTypes.REQUEST_JOBS_DATA }),
//   };
// };

//export default connect(mapStateToProps, mapDispatchToProps)(App);
export default connect(mapStateToProps)(App);
