import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"



import { Slider, Switch } from 'antd';



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
      <div>
        <Slider defaultValue={30} disabled={disabled} />
        {/* <Slider range defaultValue={[20, 50]} disabled={disabled} /> */}
        Disabled: <Switch size="small" checked={disabled} onChange={this.handleDisabledChange} />
      </div>
    )
  }
}