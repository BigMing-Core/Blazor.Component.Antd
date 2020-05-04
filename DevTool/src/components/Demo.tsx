import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";

 

import { Pagination } from 'antd';
 
export class Demo extends Component<any, any> {

  
  

  render() {

    return (
      <Pagination defaultCurrent={1} total={50} />

    );
  }
}
