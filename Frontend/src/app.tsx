import React from 'react'

export class App extends React.Component<{}, {count: number}> {
    constructor() {
        super({})
        this.state = {
            count: 0
        }
    }

    render() {
        return (
            <div>
                <h1>Welcome to my app</h1>
                <p>The current count is: {this.state.count}</p>
                <button onClick={_ => this.setState(state => ({...state, count: this.state.count + 1}))}>increase the count by 1</button>
            </div>
        )
    }
}
