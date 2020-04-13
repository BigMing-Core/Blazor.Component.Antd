import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"





import { Menu, Dropdown, Button, message, Tooltip } from 'antd';
import { DownOutlined, UserOutlined } from '@ant-design/icons';
const { SubMenu } = Menu;
const menu = (
  <Menu>
    <Menu.Item key="1">1st menu item</Menu.Item>
    <Menu.Item key="2">2nd menu item</Menu.Item>
    <Menu.Item key="3">3rd menu item</Menu.Item>
  </Menu>
);
export class Demo extends Component<any, any>{
 
  render() {
    return (
      <Dropdown overlay={menu} trigger={['contextMenu']}>
      <div
        className="site-dropdown-context-menu"
        style={{
          textAlign: 'center',
          height: 200,
          lineHeight: '200px',
        }}
      >
        Right Click on here
      </div>
    </Dropdown>

    )
  }
}