import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";

import { Drawer, Button, Spin, Alert, Switch } from "antd";

export class Demo extends Component<any, any> {
  state = { visible: false ,loading: false };
  showDrawer = () => {
    this.setState({
      visible: true,
    });
  };

  onClose = () => {
    this.setState({
      visible: false,
    });
  };

  toggle = (value:boolean) => {
    this.setState({ loading: value });
  };
  render() {
    return (<div>
      <Spin spinning={this.state.loading} size="small" delay={2000}>
        {/* <Alert
          message="Alert message title"
          description="Further details about the context of this alert."
          type="info"
        /> */}
      </Spin>
      <div style={{ marginTop: 16 }}>
        Loading state：
        <Switch checked={this.state.loading} onChange={this.toggle} />
      </div>
    </div>);
  }
}
