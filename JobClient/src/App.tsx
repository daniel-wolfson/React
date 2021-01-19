import React from "react";
import "./App.css";
import { JobViewChart } from "./components/JobViewChart";
import { Layout } from "./components/Layout";

function App() {
  return (
    <div className="App">
      <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.min.css' />
      <Layout>
        <JobViewChart />
      </Layout>
    </div>
  );
}

export default App;
