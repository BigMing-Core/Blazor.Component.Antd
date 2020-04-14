import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"




import { InputNumber } from 'antd';

function onChange(value: any) {
  console.log('changed', value);
}




export class Demo extends Component<any, any>{

  render() {
    return (
      <div className="site-input-number-wrapper">
        <InputNumber size="large" min={1} max={100000} defaultValue={3} onChange={onChange} />
        <InputNumber min={1} max={100000} defaultValue={3} onChange={onChange} />
        <InputNumber size="small" min={1} max={100000} defaultValue={3} onChange={onChange} />
      </div>
    )
  }
}