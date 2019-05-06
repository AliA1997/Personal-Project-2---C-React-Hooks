import React from 'react';
import { MainContext } from './Provider';


export default class Consumer extends React.Component {
    render() {
        const { children } = this.props;
        return (
            <MainContext.Consumer>
                {(context) => {
                    return React.Children.map(children, child => {
                        return React.cloneElement(child, context);
                    });

                }}
            </MainContext.Consumer>
        );
    }
}