import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"


import { Menu, Button } from 'antd';
import {
  AppstoreOutlined,
  MenuUnfoldOutlined,
  MenuFoldOutlined,
  PieChartOutlined,
  DesktopOutlined,
  ContainerOutlined,
  MailOutlined,
} from '@ant-design/icons';

const { SubMenu } = Menu;





const DemoBox = (props: { value: any; children: React.ReactNode }) => <p style={{ height: props.value }}>{props.children}</p>;
export class Demo extends Component<any, any>{
  state = {
    collapsed: false,
  };

  toggleCollapsed = () => {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  };
  render() {
    return (
      <div style={{ width: 256 }}>
      <Button type="primary" onClick={this.toggleCollapsed} style={{ marginBottom: 16 }}>
        {React.createElement(this.state.collapsed ? MenuUnfoldOutlined : MenuFoldOutlined)}
      </Button>
      <Menu
        defaultSelectedKeys={['1']}
        defaultOpenKeys={['sub1']}
        mode="inline"
        theme="dark"
        inlineCollapsed={this.state.collapsed}
      >
       
       <SubMenu
          key="sub21"
          title={
            <span>
              <AppstoreOutlined />
              <span>Navigation Two</span>
            </span>
          }
        >
          <Menu.Item key="91">Option 9</Menu.Item>
          <Menu.Item key="101">Option 10</Menu.Item>
          <SubMenu key="sub31" title="Submenu">
            <Menu.Item key="111">Option 11</Menu.Item>
            <Menu.Item key="121">Option 12</Menu.Item>
          </SubMenu>
        </SubMenu>
        <Menu.Item key="2">
          <DesktopOutlined />
          <span>Option 2</span>
        </Menu.Item>
        <Menu.Item key="3">
          <ContainerOutlined />
          <span>Option 3</span>
        </Menu.Item>
        <SubMenu
          key="sub1"
          title={
            <span>
              <MailOutlined />
              <span>Navigation One</span>
            </span>
          }
        >
          <Menu.Item key="5">Option 5</Menu.Item>
          <Menu.Item key="6">Option 6</Menu.Item>
          <Menu.Item key="7">Option 7</Menu.Item>
          <Menu.Item key="8">Option 8</Menu.Item>
        </SubMenu>
        <SubMenu
          key="sub2"
          title={
            <span>
              <AppstoreOutlined />
              <span>Navigation Two</span>
            </span>
          }
        >
          <Menu.Item key="9">Option 9</Menu.Item>
          <Menu.Item key="10">Option 10</Menu.Item>
          <SubMenu key="sub3" title="Submenu">
            <Menu.Item key="11">Option 11</Menu.Item>
            <Menu.Item key="12">Option 12</Menu.Item>
          </SubMenu>
        </SubMenu>

      </Menu>
    </div>

    )
  }
}