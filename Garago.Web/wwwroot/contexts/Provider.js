import React from 'react';
import * as utils from '../utilities/utils';
import authApi from '../api/AuthApi/authApi';

const initialState = {
    selectedItem: '',
    currentUser: null
};

export const MainContext = React.createContext(initialState);

export default class Provider extends React.Component {

    state = initialState;

    selectItem = (e, itemSelected) => {
        this.setState({selectedItem: itemSelected});
    }


    setUser = (currentUser) => {
        this.setState({currentUser})
    }

    render() {
        return (
            <MainContext.Provider
                value={{
                    ...this.state,
                    selectNavItem: this.selectItem,
                    setHoveredItem: this.hoverItem,
                    handleShowModal: this.handleShowModal,
                    setUser: this.setUser,
                    history: this.props.history
                }}
            >
                {this.props.children}
            </MainContext.Provider>
        );
    }
}