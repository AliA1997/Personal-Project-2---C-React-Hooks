import React, { Component } from 'react';

const initialState = {
    updateForm: {
        email: '',
        username: '',
        image: ''
    }
};

export const UserContext = React.createContext(initialState);

export default class UserProvider extends Component {
    state = initialState;

    render() {
        return (
            <UserContext.Provider
                value={{
                    ...this.state

                }}
            >
                {this.props.children}
            </UserContext.Provider>
        );
    }
}