import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { Tag } from 'antd';

function log(e: any) {
  console.log(e);
}

function preventDefault(e: any) {
  e.preventDefault();
  console.log('Clicked! But prevent default.');
}

export class Demo extends Component<any, any> {




  render() {

    return (
      <div>
        <h4 style={{ marginBottom: 16 }}>Presets:</h4>
        <div>
          <Tag color="magenta">magenta</Tag>
          <Tag color="red">red</Tag>
          <Tag color="volcano">volcano</Tag>
          <Tag color="orange">orange</Tag>
          <Tag color="gold">gold</Tag>
          <Tag color="lime">lime</Tag>
          <Tag color="green">green</Tag>
          <Tag color="cyan">cyan</Tag>
          <Tag color="blue">blue</Tag>
          <Tag color="geekblue">geekblue</Tag>
          <Tag color="purple">purple</Tag>
        </div>
        <h4 style={{ margin: '16px 0' }}>Custom:</h4>
        <div>
          <Tag color="#f50">#f50</Tag>
          <Tag color="#2db7f5">#2db7f5</Tag>
          <Tag color="#87d068">#87d068</Tag>
          <Tag color="#108ee9">#108ee9</Tag>
        </div>
      </div>
    );
  }
}
