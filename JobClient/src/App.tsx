import React from "react";
import "./App.css";
import { JobViewChart } from "./components/JobViewChart";
import { Layout } from "./components/Layout";

function App() {
  return (
    <div className="App">
      <Layout>
        <JobViewChart />
      </Layout>
    </div>
  );
}

export default App;
