import * as React from "react";
import { Component } from "react";
import * as ReactDOM from "react-dom";
import "antd/dist/antd.css";
import "./demo.less";


import { Tag } from 'antd';

const { CheckableTag } = Tag;
import {
  CheckCircleOutlined,
  SyncOutlined,
  CloseCircleOutlined,
  ExclamationCircleOutlined,
  ClockCircleOutlined,
  MinusCircleOutlined,
} from '@ant-design/icons';
export class Demo extends Component<any, any> {




  render() {

    return (
      <div>
        <h4>With icon</h4>
        <Tag icon={<CheckCircleOutlined />} color="success">
          success
      </Tag>
        <Tag icon={<SyncOutlined spin />} color="processing">
          processing
      </Tag>
        <Tag icon={<CloseCircleOutlined />} color="error">
          error
      </Tag>
        <Tag icon={<ExclamationCircleOutlined />} color="warning">
          warning
      </Tag>
        <Tag icon={<ClockCircleOutlined />} color="default">
          waiting
      </Tag>
        <Tag icon={<MinusCircleOutlined />} color="default">
          stop
      </Tag>
      </div>
    );
  }
}
