import React from "react";
import { Bar } from "react-chartjs-2";

interface IProps {}

export interface IState {
  data: (string | number)[][];
  options: {};
}

const rand = () => Math.round(Math.random() * 20 - 10);

export class JobViewChart extends React.Component {
  
  options = {
    title: {
      display: true,
      text: "Comulative job views vs. prediction",
      fontSize: 20,
    },
    legend: {
      display: true,
      position: "bottom",
      labels: {
        fontColor: "#323130",
        fontSize: 14,
      },
    },
    vAxis: { title: "Job views" },
    hAxis: { title: "Jobs" }
  };

  constructor(props: IProps) {
    super(props);

    this.state = {
      labels: ["January", "February", "March", "April", "May"],
      datasets: [
        {
          type: "line",
          label: "Dataset 1",
          borderColor: "rgb(54, 162, 235)",
          borderWidth: 15,
          fill: false,
          data: [
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
          ],
          pointBorderColor: "rgba(75,192,192,1)",
          pointBackgroundColor: "#fff",
          pointBorderWidth: 1,
          pointHoverRadius: 12,
          pointHoverBackgroundColor: "rgba(75,192,192,1)",
          pointHoverBorderColor: "rgba(220,220,220,1)",
          pointHoverBorderWidth: 2,
          pointRadius: 10,
          pointHitRadius: 10,
        },
        {
          type: "line",
          label: "Dataset 2",
          borderColor: "rgb(154, 162, 235)",
          borderWidth: 2,
          fill: false,
          data: [
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
            rand(),
          ],
        },
        {
          type: "bar",
          label: "Dataset 2",
          backgroundColor: "rgb(255, 99, 132)",
          data: [rand(), rand(), rand(), rand(), rand(), rand(), rand()],
          borderColor: "white",
          borderWidth: 2,
        },
      ],
    };
  }

  render() {
    return (
      <>
        <Bar data={this.state} options={this.options} />
      </>
    );
  }
}
