import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { Input } from 'antd';
import { UserOutlined,SettingOutlined  } from '@ant-design/icons'


export class Demo extends Component<any, any> {


  render() {

    return (
      <div>
        <div style={{ marginBottom: 16 }}>
          <Input addonBefore="http://" addonAfter=".com" defaultValue="mysite" />
        </div>
      
        <div style={{ marginBottom: 16 }}>
          <Input addonAfter={<SettingOutlined />} defaultValue="mysite" />
        </div>
        <div style={{ marginBottom: 16 }}>
          <Input addonBefore="http://"    suffix=".com" defaultValue="mysite" />
        </div>
        
        <div style={{ marginBottom: 16 }}>
          <Input addonBefore="http://"  addonAfter=".com"  suffix=".com" defaultValue="mysite" />
        </div>

        <Input prefix="￥" suffix="RMB" />
      </div>

    );
  }
}
