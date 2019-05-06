import React from 'react';
import { AuthContext } from './AuthProvider';

const AuthConsumer = (props) => {
    console.log('props---------', props);
    return (
        <AuthContext.Consumer>
            {context => {
                return React.Children.map(props.children, child => {
                    return React.cloneElement(child, context);
                })
            }}
        </AuthContext.Consumer>
    );
};

export default AuthConsumer;