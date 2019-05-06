import React, { Component } from 'react';
import { Grommet } from 'grommet';
import { Route, Switch } from 'react-router';
import Provider from '../contexts/Provider';
import AuthProvider from '../contexts/auth/AuthProvider';
import Consumer from '../contexts/Consumer';
import * as styleUtils from '../utilities/styleUtils';
import AuthenticatedWrapper from '../components/AuthenticatedWrapper.web';
import AuthConsumer from '../contexts/auth/AuthConsumer';


export default class App extends Component {

    render() {
        return (
            <Grommet
                theme={styleUtils.theme}
            >   
                                
                
                    <Consumer>
                        <AuthProvider>
                            
                            <AuthConsumer>
                                
                                <AuthenticatedWrapper />

                            </AuthConsumer>

                        </AuthProvider>

                    </Consumer>
                

            </Grommet>
        );
    }
}