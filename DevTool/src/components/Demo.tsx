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

  handleSelect = (e: any) => {
    console.log('select ', e);
    this.setState({
      current: e.key,
    });
  };

  render() {
    return (
      <Menu onClick={this.handleClick} onSelect={this.handleSelect} multiple={true} selectedKeys={[this.state.current]} mode="horizontal">

        <SubMenu
          title={
            <span className="submenu-title-wrapper">
              <SettingOutlined />
              Navigation Three - Submenu
            </span>
          }
        >
          <Menu.ItemGroup title={<span>asdasdsad</span>}>

            <Menu.Divider></Menu.Divider>
            <Menu.Item key="setting:1">Option 1</Menu.Item>
            <Menu.Divider></Menu.Divider>
          </Menu.ItemGroup>
          <Menu.ItemGroup title="Item 2">
            <Menu.Item key="setting:3">Option 3</Menu.Item>
            <Menu.Item key="setting:4">Option 4</Menu.Item>
          </Menu.ItemGroup>
        </SubMenu>

        <Menu.Item key="mail">
          <MailOutlined />
          Navigation One
        </Menu.Item>

      </Menu>
    )
  }
}