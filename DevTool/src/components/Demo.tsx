import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { Input } from 'antd';
import { UserOutlined } from '@ant-design/icons'


export class Demo extends Component<any, any> {


  render() {

    return (
      <div>
        <Input placeholder="Basic usage" disabled />
        <br />
        <Input size="large" placeholder="large size" prefix={<UserOutlined />} />
        <br />
        <br />
        <Input placeholder="default size" prefix={<UserOutlined />} />
        <br />
        <br />
        <Input size="small" placeholder="small size" prefix={<UserOutlined />} />

      </div>

    );
  }
}
