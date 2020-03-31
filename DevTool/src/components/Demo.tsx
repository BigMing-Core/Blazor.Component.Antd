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
} from '@ant-design/icons';

const { SubMenu } = Menu;




 

const DemoBox = (props: { value: any; children: React.ReactNode }) => <p style={{ height: props.value }}>{props.children}</p>;
export class Demo extends Component<any, any>{


  state = {
    current: 'mail',
  };

  handleClick = (e:any) => {
    console.log('click ', e);
    this.setState({
      current: e.key,
    });
  };

  render() {
    return (
      <Menu onClick={this.handleClick}>
  
      
    </Menu>
    )
  }
}