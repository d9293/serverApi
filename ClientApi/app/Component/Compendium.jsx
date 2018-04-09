import React, { Component } from 'react';
import axios from 'axios';

export default class Compenduim extends Component {
    constructor() {
        super();
        this.state = {
            test: 'compenduim'
        }
    }
    componentDidMount() {
        axios.get('http://localhost:60009/api/compendium/get')
            //.then(response => this.setState({ test: response.data.test }))
            .then(response => console.log(response));
    }

    render() {
        return (
            <div>
                <h1>
                    {this.state.test}
                </h1>
            </div>
        );
    }
}