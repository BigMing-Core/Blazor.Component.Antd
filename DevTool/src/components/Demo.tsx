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
  <Menu.Item>1st menu item</Menu.Item>
  <Menu.Item>2nd menu item</Menu.Item>
  <SubMenu title="sub menu">
    <Menu.Item>3rd menu item</Menu.Item>
    <Menu.Item>4th menu item</Menu.Item>
  </SubMenu>
  <SubMenu title="disabled sub menu" disabled>
    <Menu.Item>5d menu item</Menu.Item>
    <Menu.Item>6th menu item</Menu.Item>
  </SubMenu>
</Menu>
);
export class Demo extends Component<any, any>{
 
  render() {
    return (
      <Dropdown overlay={menu}>
      <Button>
        Button <DownOutlined />
      </Button>
    </Dropdown>

    )
  }
}