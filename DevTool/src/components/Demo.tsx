import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";

import { Slider, Spin } from "antd";
export class Demo extends Component<any, any> {
  state = {
    disabled: false,
  };

  handleDisabledChange = (disabled: any) => {
    this.setState({ disabled });
  };

  render() {
    const { disabled } = this.state;
    return (
      <Spin
        size="large"
        wrapperClassName="aaa"
        className="bbbss"
        tip="bbs"
        delay={2}
        spinning={true}
        style={{
          width: 40,
        }}
        //indicator={<div>aaa</div>}
      />
    );
  }
}
