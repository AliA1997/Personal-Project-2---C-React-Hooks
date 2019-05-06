import React, { Component } from 'react';
import Navigation from '../constants/Navigation.web';
import Navbar from '../components/Navbar';
import Header from '../constants/Header';
import PropTypes from 'prop-types';
import SetTitleRoute from '../constants/SetTitleRoute';
import Consumer from '../contexts/Consumer';
import AuthConsumer from '../contexts/auth/AuthConsumer';
import { Switch } from 'react-router';
import { Box } from 'grommet';
import AuthModal from './User/AuthModal';

export default class AuthenticatedWrapper extends Component {
    constructor() {
        super();
        //Set the reidrectUrl, if the user isn't logged then redirect the user.
        // const redirectUrl = this.props.location.pathname;

        // if (this.props.accessToken === "") {
        //     this.props.actions.setRedirectUrl(redirectUrl);
        //     this.props.history.replace("/");
        // }
    }
    render() {
        console.log('this.props---------', this.props)
        const { currentUser, history, selectedItem, selectNavItem, handleShowModal, showLogin, showSignup} = this.props;
        return (
            <Box>
                <Consumer>
                    <Navbar history={history} selectedItem={selectedItem} selectItem={selectNavItem} currentUser={currentUser} handleShowModal={handleShowModal} showLogin={showLogin} showSignup={showSignup}/>
                </Consumer>
                <Box>
                    
                    <Switch>
                        {
                            //Loop through your array objects
                            Navigation.map((navItem, i) => {
                                const roleToCompare = currentUser ? currentUser.role : 'Buyer';
                                
                                if(navItem.roles.includes(roleToCompare) || navItem.roles.includes('All')) 
                                    return (
                                        <SetTitleRoute path={navItem.url} title={navItem.name} key={i} exact={navItem.exact}>

                                            <React.Fragment>
                                                {/**Each route has a corresponding header and component */}
                                                <Header title={navItem.subtitle} icon={navItem.icon} />
                                                <navItem.component />
                                            </React.Fragment>
                                    
                                        </SetTitleRoute>
                                    );
                                
                                return null;
                            })
                        }
                    </Switch>
                </Box>
            </Box>
        );
    }
}

AuthenticatedWrapper.propTypes = {
    currentUser: PropTypes.object,
    history: PropTypes.object,
    selectedItem: PropTypes.string,
    hoveredItem: PropTypes.string,
    selectNavItem: PropTypes.func,
    setHoveredItem: PropTypes.func,
    login: PropTypes.func,
    setUser: PropTypes.func,
    logout: PropTypes.func
}