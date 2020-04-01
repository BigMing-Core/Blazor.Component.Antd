import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"


import { Menu } from 'antd';
import {
  MailOutlined,
  AppstoreOutlined,
  SettingOutlined,
  StepBackwardOutlined,
} from '@ant-design/icons';

const { SubMenu } = Menu;






const DemoBox = (props: { value: any; children: React.ReactNode }) => <p style={{ height: props.value }}>{props.children}</p>;
export class Demo extends Component<any, any>{


  state = {
    current: 'mail',
  };

  handleClick = (e: any) => {
    console.log('click ', e);
    this.setState({
      current: e.key,
    });
  };

  render() {
    return (
      <Menu onClick={this.handleClick} selectedKeys={[this.state.current]} mode="horizontal">
        <Menu.Item key="mail">
          <MailOutlined />
          Navigation One
        </Menu.Item>
        <SubMenu
          title={
            <span className="submenu-title-wrapper">
              <SettingOutlined />
              Navigation Three - Submenu
            </span>
          }
        >
          <Menu.ItemGroup title="Item 1">
            <Menu.Item key="setting:1">Option 1</Menu.Item>
            <Menu.Item key="setting:2">Option 2</Menu.Item>
          </Menu.ItemGroup>
          <Menu.ItemGroup title="Item 2">
            <Menu.Item key="setting:3">Option 3</Menu.Item>
            <Menu.Item key="setting:4">Option 4</Menu.Item>
          </Menu.ItemGroup>
        </SubMenu>

        
        <SubMenu
          title={
            <span className="submenu-title-wrapper">
              <SettingOutlined />
              Navigation Three - Submenu
            </span>
          }
        >
          <Menu.ItemGroup title="Item 11">
            <Menu.Item key="setting:11">Option 11</Menu.Item>
            <Menu.Item key="setting:22">Option 22</Menu.Item>
          </Menu.ItemGroup>
          <Menu.ItemGroup title="Item 22">
            <Menu.Item key="setting:33">Option 33</Menu.Item>
            <Menu.Item key="setting:44">Option 44</Menu.Item>
          </Menu.ItemGroup>
        </SubMenu>


        <Menu.Item key="alipay">
          <a href="https://ant.design" target="_blank" rel="noopener noreferrer">
            Navigation Four - Link
          </a>
        </Menu.Item>
      </Menu>
    )
  }
}