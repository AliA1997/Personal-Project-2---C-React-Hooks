import React, { Component } from 'react';
import sha256 from 'crypto-js/sha256';
import authApi from '../../api/AuthApi/authApi';
import * as utils from '../../utilities/utils';

const initialState = {
    authForm: {
        displayName: '',
        password: ''
    },
    registerForm: {
        name: '',
        displayName: '',
        password: '',
        avatar: '',
    }
};

export const AuthContext = React.createContext(initialState);

export default class AuthProvider extends Component {
    state = initialState;

    handleLoginChange = (e, type) => {
        const { authForm } = this.state;
        const form = utils.deepCopy(authForm);
        form[type] = e.target.value;
        this.setState({authForm: form});
    }

    handleRegisterChange = (e, type) => {
        const { registerForm } = this.state;
        const form = utils.deepCopy(registerForm);
        form[type] = e.target.value;
        this.setState({registerForm: form});
    }

    loginUser = async (e) => {
        //Stop event bubbling.
        e.preventDefault();
        //Destruct the authForm from state.
        const { authForm } = this.state;
        //Login your currentUser
        const currentUser = await authApi.login(authForm);
        //Set your currentUser
        this.props.setUser(currentUser);
        //Reset your authForm state.
        this.setState({
                        authForm: {
                                displayName: '',
                                password: ''
                            }
                        });
    }

    register = async (e) => {
        //Stop event bubbling
        e.preventDefault();
        //Destruct your registerForm from state.
        const { registerForm } = this.state;
        //Get the currentUser using the authApi
        const currentUser = await authApi.register(registerForm);
        //Set the curentUser
        this.props.setUser(currentUser);
        //Reset your registerForm
        this.setState({
                        registerForm: {
                            name: '',
                            displayName: '',
                            password: '',
                            avatar: '',
                        }
                    });
    }

    callFacebookApi = async (response) => {
        const user = await authApi.loginFacebook(response.authResponse);
        this.props.setUser(user);
    }

    loginFacebook = async (e) => {
        e.preventDefault();

        //Use facebook api to login a user, if they are already logged in then log them in using your endpoint that will log them in.
        FB.getLoginStatus(response => {
            
            if (response.status === "connected") {
                
                //If the currentUser is not logged in then log them in.
                if(this.props.currentUser == {} || !this.props.currentUser) {
                    this.callFacebookApi(response);
                }

            } else {
            
                FB.login(response => {
                    //IF the response is successful log the user in.
                    if (response.authSuccess) {
                        this.callFacebookApi(response);
                    }
                }, { scope: "email,public_profile", info_fields: "email,name" });
          
            }
          });
    }

    logoutUser = async e => {
        //Stop event bubbling
        e.preventDefault();
        //Logout the user
        await authApi.logout();
        ///If the currentUser logged out is facebook type.
        if(this.props.currentUser.type === 'facebook') {
            FB.logout(function(response) {
                // Person is now logged out
                console.log('response');
             });
        }
        //Then set the currentUser to null
        this.props.setUser(null);
    }

    reset = () => {
        this.setState({
            authForm: {
                displayName: '',
                password: ''
            },
            registerForm: {
                name: '',
                displayName: '',
                password: '',
                avatar: '',
            }
        });
    }

    render() {
        console.log('props--------', this.props)
        return (
            <AuthContext.Provider
                value={{
                    ...this.props,
                    ...this.state,
                    handleLoginChange: this.handleLoginChange,
                    handleRegisterChange: this.handleRegisterChange,
                    reset: this.reset,
                    loginUser: this.loginUser,
                    logoutUser: this.logoutUser,
                    register: this.register,
                    facebookLogin: this.loginFacebook
                }}
            >
                {this.props.children}
            </AuthContext.Provider>
        );
    }
}