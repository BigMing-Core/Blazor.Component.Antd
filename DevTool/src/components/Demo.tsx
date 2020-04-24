import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { Row,Col } from 'antd';

import { Badge } from 'antd';
import { ClockCircleOutlined } from '@ant-design/icons';



export class Demo extends Component<any, any> {
 
  render() {
    return (
      <Row gutter={24}>
        <Col span={24}><br/></Col>
    <Col span={2}></Col>
    <Col span={2}>
    <Badge count={32}>
      <a href="#" className="head-example" />
    </Badge>
    </Col>
    {/* <Col span={2}>
    <Badge count={0} showZero>
      <a href="#" className="head-example" />
    </Badge>
    </Col>
    <Col span={2}>
    <Badge count={<ClockCircleOutlined style={{ color: '#f5222d' }} />}>
      <a href="#" className="head-example" />
    </Badge>
    </Col>  */}
  </Row>
    );
  }
}
