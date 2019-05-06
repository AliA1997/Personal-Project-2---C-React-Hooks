import React from 'react';
import { GarageSaleContext } from './GarageSaleProvider';
import * as utils from '../../utilities/utils';


export default class GarageSaleConsumer extends React.Component {
    render() {
        const { children } = this.props;
        return (
            <GarageSaleContext.Consumer>
                {context => {
                    return React.Children.map(children, child => {
                        console.log('context----------', context);
                        return React.cloneElement(child, context);
                    })
                }}
            </GarageSaleContext.Consumer>
        );
    }
}