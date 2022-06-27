import React from 'react'
import ReactDom from 'react-dom'
import { App } from './src/app'
import './base.css'

export const main = () => {
    ReactDom.render(<App />, document.getElementById("root"))
}

document.addEventListener("DOMContentLoaded", main)