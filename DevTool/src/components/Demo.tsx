import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"



import { Input } from 'antd';
export class Demo extends Component<any, any>{
  state = {
    disabled: false,
  };

  handleDisabledChange = (disabled:any) => {
    this.setState({ disabled });
  };

  render() {
    const { disabled } = this.state;
    return (
      <Input placeholder="Basic usage" disabled={true} />
    )
  }
}