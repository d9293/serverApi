import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import Compendium from './Component/Compendium.jsx';
import Report from './Component/Report.jsx';
import Layout from './Common/Layout.jsx';

export default class App extends Component {
    render() {
        return (
            <Router Component={Layout}>
                <div>
                    <Layout />
                    <Switch>
                        <Route path='/' component={Compendium} />
                        <Route path='/Login' component={Report} />
                    </Switch>
                </div>
            </Router>
        );
    }
}