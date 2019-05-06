import React, { Component } from 'react';
import { UserContext } from './UserProvider';

export default class UserConsumer extends Component {
    render() {
        const { children } = this.props;
        return (
            <UserContext.Consumer>
                {context => {
                    return React.Children.map(children, child => {
                        return React.cloneElement(child, context);
                    })
                }}
            </UserContext.Consumer>            
        );
    }
}