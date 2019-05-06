import React, { useEffect, useState }  from 'react';
import { Layer, Heading } from 'grommet';
import GaragoForm from '../../utilities/Form';
import SocialMediaButton from '../../utilities/nonInputs/SocialMediaButton';

const AuthModal = (props) => {

    const [ showAuthState, setShowAuth ] = useState(false);

    const { selectedItem, handleRegisterChange, handleLoginChange, reset, register, 
            loginUser, registerForm, authForm, facebookLogin, logoutUser } = props;

    const registerFields = Object.keys(registerForm).map(rkey => {
        return {
            propertyName: rkey,
            type: rkey,
            value: registerForm[rkey]
        };
    });

    const loginFields = Object.keys(authForm).map(lkey => {
        return {
            propertyName: lkey,
            type: lkey,
            value: authForm[lkey]
        };
    });
    
    function showAuthModal(bool) {
        setShowAuth(bool);
    }

    function authFunction(e, type) {
        if(type === 'register')
            register(e);
        else if(type === 'login')
            loginUser(e);
        else if(type === 'facebook-login')
            facebookLogin(e)

        setShowAuth(false);
    }


    console.log('props-----------', props);
    return (
        <React.Fragment>
            {
            showAuthState ? 
                <Layer
                    className="form-modal"
                    responsive={true}
                    animate={true}
                    onEsc={() => showAuthModal(false)}
                    onClickOutside={() => showAuthModal(false)}
                >
                    {
                        <Heading size="small" responsive={true}>{selectedItem === 'sign_up' ? 'Register' : 'Login'}</Heading>
                    }
                    <SocialMediaButton type="facebook" onClick={(e) => facebookLogin(e)} />
                    <div className="fb-login-button" data-size="large" data-button-type="continue_with" data-auto-logout-link="false" data-use-continue-as="false"></div>
                    <SocialMediaButton type="twitter" onClick={() => console.log('')} />
                    <SocialMediaButton type="google" onClick={() => console.log('')} />
                    {
                        selectedItem === 'sign_up' ?
                            <GaragoForm 
                                onChange={handleRegisterChange}
                                onSubmit={authFunction}
                                onReset={reset}
                                fields={registerFields}
                                typeOfForm="register"
                                isAuth={true}
                                doCreate={false}
                            />
                            : <GaragoForm 
                                onChange={handleLoginChange}
                                onSubmit={authFunction}
                                onReset={reset}
                                fields={loginFields}
                                typeOfForm="login"
                                isAuth={true}
                                doCreate={false}
                            />
                    }
                </Layer>
                : null 
            }
        </React.Fragment>
    );
};

export default AuthModal;