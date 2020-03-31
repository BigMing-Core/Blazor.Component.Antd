import * as React from "react"
import { Component } from "react"
import * as ReactDOM from "react-dom"
import "antd/dist/antd.css"
import "./demo.less"


import { Button } from 'antd';




 

const DemoBox = (props: { value: any; children: React.ReactNode }) => <p style={{ height: props.value }}>{props.children}</p>;
export class Demo extends Component<any, any>{
  render() {
    return (
      <div>
    <Button type="primary">asdasd</Button>
    <Button>Default</Button>
    <Button type="dashed" size="middle">Dashed</Button>
    <Button type="link">Link</Button>
  </div>
    )
  }
}