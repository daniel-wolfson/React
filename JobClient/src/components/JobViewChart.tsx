import React from "react";
import { Bar } from "react-chartjs-2";
import { Job } from "../models/job.model";
import { JobView } from "../models/jobview.model";

interface IProps {
  appLoading: boolean;
  jobs: Job[];
  jobViews: JobView[];
}

export interface IState {
  labels: [];
  datasets: [][];
}

const months = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

const convertDate = (date_str: string) => {
  const temp_date = new Date(date_str);
  return months[temp_date.getMonth() - 1] + " " + temp_date.getDate();
};

const rand = () => Math.round(Math.random() * 20 - 10);

export class JobViewChart extends React.Component<any, any> {
  options: {};

  constructor(props: IProps) {
    super(props);

    let labels: string[] = [];
    let activeJobs: number[] = [];
    let views: number[] = [];
    let viewsPredicted: number[] = [];

    if (props.jobViews && props.jobViews.length) {
      labels = props.jobViews
        ? props.jobViews.map((x) => convertDate(x.viewDate))
        : [];

        activeJobs = props.jobViews.map((x) => x.activeJobs);
      views = props.jobViews.map((x) => x.views);
      viewsPredicted = props.jobViews.map((x) => x.viewsPredicted);
    }

    this.options = {
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
      scales: {
        yAxes: [
          {
            title: "Job views",
            ticks: {
              suggestedMin: 0,
              suggestedMax: 1000,
            },
          },
        ],
      },
    };

    this.state = {
      labels: labels, //["January", "February", "March", "April", "May"],
      datasets: [
        {
          type: "line",
          label: "Job views",
          borderColor: "rgb(54, 162, 235)",
          borderWidth: 15,
          fill: false,
          data: views,
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
          label: "Predicted job views",
          borderColor: "rgb(154, 162, 235)",
          borderWidth: 2,
          fill: false,
          data: viewsPredicted,
        },
        {
          type: "bar",
          label: "Jobs",
          backgroundColor: "rgb(255, 99, 132)",
          data: activeJobs,
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
