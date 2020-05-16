import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { DatePicker } from 'antd';

function onChange(date:any, dateString:any) {
  console.log(date, dateString);
}


export class Demo extends Component<any, any> {

  render() {

    return (
      <div>
        <DatePicker onChange={onChange}  />
        {/* <br />
        <DatePicker onChange={onChange} picker="week" />
        <br />
        <DatePicker onChange={onChange} picker="month" />
        <br />
        <DatePicker onChange={onChange} picker="quarter" />
        <br />
        <DatePicker onChange={onChange} picker="year" /> */}
      </div> 
    );
  }
}
