import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { message, Button } from 'antd';

const success = () => {
  message
    .loading('Action in progress..', 0);
    message
    .error('Action in progress..', 0);
    message
    .success('Action in progress..', 0);
    message
    .info('Action in progress..', 0);
    message
    .warning('Action in progress..', 0); 
    message
    .loading('Action in progress..', 0);
};
export class Demo extends Component<any, any> {
 
 
  render() {
    
    return (
      <Button onClick={success}>Display sequential messages</Button>
    );
  }
}
