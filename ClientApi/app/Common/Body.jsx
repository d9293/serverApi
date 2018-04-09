import React, {Component} from 'react';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import Compendium from '../Component/Compendium';
import Report from '../Component/Report';

export default class Body extends Component{
    constructor(){
        super();
    }
    render(){
        return (
            <Router>
                <div>
                    <ul>
                        <li><Link to={'/'}>Home</Link></li>
                        <li><Link to={'/Login'}>Login</Link></li>
                    </ul>
                    <hr />
                    <Switch>
                        <Route exact path='/' component={Compendium} />
                        <Route exact path='/Login' component={Report} />
                    </Switch>
                </div>
            </Router>
        );
    }
} 