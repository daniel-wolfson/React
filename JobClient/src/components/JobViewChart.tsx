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
        xAxes: [
          {
            scaleLabel: {
              display: true,
              labelString: "",
            },
          },
        ],
        yAxes: [
          {
            type: "linear",
            display: true,
            position: "left",
            id: "y-axis-jobViews",
            scaleLabel: {
              display: true,
              labelString: "Job views",
            },
            ticks: {
              beginAtZero: true,
              autoSkip: true,
              suggestedMin: 0,
              suggestedMax: 1500,
              stepSize: 500,
            },
          },
          {
            type: "linear",
            display: true,
            position: "right",
            gridLines: {
              display: false,
            },
            id: "y-axis-jobs",
            scaleLabel: {
              display: true,
              labelString: "Jobs",
            },
            ticks: {
              beginAtZero: true,
              autoSkip: true,
              suggestedMin: 0,
              suggestedMax: 100,
              stepSize: 50,
            },
          },
        ],
      },
      tooltips: {
        bodyFontColor: "black",
        titleFontColor: "black",
        backgroundColor: "white",
        borderColor: "gray",
        borderWidth: "1",
        displayColors: false,
        custom: function (tooltip: any) {
          if (!tooltip) return;
        },
        callbacks: {
          title: function (tooltipItem: any, data: any) {
            return data.labels[tooltipItem[0].index];
          },
          beforeLabel: function (tooltipItem: any, data: any) {
            //var datasetIndex = tooltipItem.datasetIndex;
            var views =
              "Job views: " + data.datasets[0].data[tooltipItem.index];
            var viewsPredicted =
              "Predicted job views: " +
              data.datasets[1].data[tooltipItem.index];
            var activeJobs =
              "Active jobs: " + data.datasets[2].data[tooltipItem.index];
            return (
              views + "\r\n" + viewsPredicted + "\r\n" + activeJobs + "\r\n"
            );
          },
          label: function (tooltipItem: any, data: any) {
            //var label = data.labels[tooltipItem.index];
            //var datasetLabel = "$" + tooltipItem.yLabel;
            return ""; //label + " " + datasetLabel
          },
        },
      },
    };

    this.state = {
      labels: labels,
      datasets: [
        {
          type: "line",
          label: "views",
          borderColor: "rgb(98, 138, 71)",
          borderWidth: 2,
          fill: false,
          data: views,
          pointBorderColor: "rgba(94, 217, 170, 1)",
          pointBackgroundColor: "rgba(94, 217, 170, 1)",
          pointBorderWidth: 1,
          pointHoverRadius: 3,
          pointHoverBackgroundColor: "rgba(75,192,192,1)",
          pointHoverBorderColor: "rgba(220,220,220,1)",
          pointHoverBorderWidth: 2,
          pointRadius: 3,
          pointHitRadius: 3,
        },
        {
          type: "line",
          label: "Predicted views",
          borderColor: "rgb(94, 203, 217)",
          borderWidth: 1,
          fill: false,
          data: viewsPredicted,
          borderDash: [1, 1],
        },
        {
          type: "bar",
          label: "active jobs",
          backgroundColor: "rgb(207, 207, 207)",
          data: activeJobs,
          borderColor: "white",
          borderWidth: 2,
        },
      ],
    };
  }

  render() {
    return (
      <div style={{
        width: "100vw",
        height: "calc(100vh - 50px)"
      }}>
        <Bar data={this.state} options={this.options} ref="chart" />
      </div>
    );
  }
}
