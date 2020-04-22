import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";






import { Card } from 'antd';

import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';




export class Demo extends Component<any, any> {
 
  render() {
    return (
      <Card title="Default size card" extra={<a href="#">More</a>} style={{ width: 300 }}
      actions={[
        <SettingOutlined key="setting" />,
        <EditOutlined key="edit" />,
        <EllipsisOutlined key="ellipsis" />,
      ]}
      >
      <p>Card content</p>
      <p>Card content</p>
      <p>Card content</p>
    </Card>
    );
  }
}
