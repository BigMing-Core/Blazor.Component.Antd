import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { message, Button } from 'antd';

const success = () => {
  message
    .loading('Action in progress..', 0)
    .then(() => message.success('Loading finished', 0))
    .then(() => message.info('Loading finished is finished', 0));
};
export class Demo extends Component<any, any> {
 
 
  render() {
    
    return (
      <Button onClick={success}>Display sequential messages</Button>
    );
  }
}
