import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";




import { Drawer, Button } from 'antd';


export class Demo extends Component<any, any> {
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
      <div className="site-drawer-render-in-current-wrapper">
        Render in this
        <div style={{ marginTop: 16 }}>
          <Button type="primary" onClick={this.showDrawer}>
            Open
        </Button>
        </div>
        <Drawer
          title="Basic Drawer"
          placement="right"
          closable={false}
          onClose={this.onClose}
          visible={this.state.visible}
          getContainer={false}
          style={{ position: 'absolute' }}
        >
          <p>Some contents...</p>
        </Drawer>
      </div>
    );
  }
}
