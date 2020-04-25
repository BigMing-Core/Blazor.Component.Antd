import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";

import { Card, Avatar, Button } from 'antd';

import { EditOutlined, EllipsisOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';

export class Demo extends Component<any, any> {
 
  render() {
    return (
      <div>
   <Avatar icon={<UserOutlined />} />
    <Avatar>U</Avatar>
    <Avatar>
      <Button>User</Button>

    </Avatar>
    <Avatar icon={<UserOutlined />}  src="https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png"  alt="bbbbb"/>
    <Avatar style={{ color: '#f56a00', backgroundColor: '#fde3cf' }}>U</Avatar>
    <Avatar style={{ backgroundColor: '#87d068' }} icon={<UserOutlined />} />
 
    <Avatar alt="user3"></Avatar>
  </div>
    );
  }
}
