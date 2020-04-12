import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"





import { Menu, Dropdown, Button } from 'antd'; const menu = (
  <Menu>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="http://www.alipay.com/">
        1st menu item
      </a>
    </Menu.Item>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="http://www.taobao.com/">
        2nd menu item
      </a>
    </Menu.Item>
    <Menu.Item>
      <a target="_blank" rel="noopener noreferrer" href="http://www.tmall.com/">
        3rd menu item
      </a>
    </Menu.Item>
  </Menu>
);
export class Demo extends Component<any, any>{
 
  render() {
    return (
      <div>
        <Dropdown overlay={menu} placement="bottomLeft">
          <Button>bottomLeft</Button>
        </Dropdown>
        <Dropdown overlay={menu} placement="bottomCenter">
          <Button>bottomCenter</Button>
        </Dropdown>
        <Dropdown overlay={menu} placement="bottomRight">
          <Button>bottomRight</Button>
        </Dropdown>
        <br />
        <Dropdown overlay={menu} placement="topLeft">
          <Button>topLeft</Button>
        </Dropdown>
        <Dropdown overlay={menu} placement="topCenter">
          <Button>topCenter</Button>
        </Dropdown>
        <Dropdown overlay={menu} placement="topRight">
          <Button>topRight</Button>
        </Dropdown>
      </div>

    )
  }
}