import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";

import { Drawer, Button } from 'antd';


export class Demo extends Component<any, any>{
  state = { visible: false };

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
  render() { 
    return ( 
      <div>
      <Button type="primary" onClick={this.showDrawer}>
        Open
      </Button>
      <Drawer
        placement="left"
        closable={true}
        onClose={this.onClose}
        visible={this.state.visible}
      >
        <p>Some contents...</p>
        <p>Some contents...</p>
        <p>Some contents...</p>
      </Drawer>
    </div>

    )
  }
}
